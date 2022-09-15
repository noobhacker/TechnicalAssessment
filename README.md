# TechnicalAssessment
![unitTests workflow](https://github.com/noobhacker/TechnicalAssessment/actions/workflows/unitTests.yml/badge.svg)
![integrationTests workflow](https://github.com/noobhacker/TechnicalAssessment/actions/workflows/integrationTests.yml/badge.svg)

This project is 
- With YAGNI principle applied, but also ensures highest testability. 
- Designed based on how the project will expand for the next six months, based on my experience.

# High level architecture design
Layer | Responsibility
--- | ---
Presentation | Handles routing, Swagger, endpoints. Serves as a catalog for Apis. Also catches exception propogation to return appropriate http status code.
Core | Handles core logic, validation and data contracts. Designed with fully isolated testability in mind. All other layers depends on Core. 
Infrastructure | External implementations such as database access based on what the Core needs. This layer is solely created so we can mock in the Core layer easier.
Persistance | Database schema, index, constraints and migrations.

# High level dependency graph

```
Presentation -> Core <- Infrastructure -> Persistance
                 ^              ^              ^
                 |              |              |
             UnitTests          IntegrationTests
```

# Low level codes

Entry point and API catalog - FeatureController.cs
```csharp
using Microsoft.AspNetCore.Mvc;
using TechnicalAssessment.Core.Features.Commands.AddFeature;
using TechnicalAssessment.Core.Features.Queries.GetFeature;

namespace TechnicalAssessment.Presentation.Controllers
{
    [ApiController]
    [Route("feature")]
    public class FeatureController : ControllerBase
    {
        private readonly GetFeatureQueryHandler _getHandler;
        private readonly AddFeatureCommandHandler _updateHandler;

        public FeatureController(GetFeatureQueryHandler getHandler,
            AddFeatureCommandHandler updateHandler)
        {
            _getHandler = getHandler;
            _updateHandler = updateHandler;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetFeatureResponse> Get(string email, string featureName)
        {
            return Ok(_getHandler.Handle(new GetFeatureQuery
            {
                email = email,
                featureName = featureName
            }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status304NotModified)]
        public ActionResult Post(AddFeatureCommand request)
        {
            _updateHandler.Handle(request);

            return Ok();
        }
    }
}
```

Core logic and validation for Get feature - GetFeatureQueryHandler.cs
```csharp
using TechnicalAssessment.Core.Exceptions;
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Core.Validators;

namespace TechnicalAssessment.Core.Features.Queries.GetFeature
{
    public class GetFeatureQueryHandler
    {
        private readonly IFeatureRepository _repository;

        public GetFeatureQueryHandler(IFeatureRepository repository)
        {
            _repository = repository;
        }

        public GetFeatureResponse Handle(GetFeatureQuery query)
        {
            if (!EmailValidator.Validate(query.email))
            {
                throw new BadRequestException("Email format is invalid.");
            }

            if (string.IsNullOrEmpty(query.featureName))
            {
                throw new BadRequestException("featureName is empty.");
            }

            var feature = _repository.Get(query.email, query.featureName);

            if (feature is null)
            {
                throw new NotFoundException("Email and feature name pair not found in our database.");
            }

            return new GetFeatureResponse
            {
                canAccess = feature.Enabled
            };
        }
    }
}
```

Core logic and validation for add feature - AddFeatureCommandHandler.cs

I notice that NotModified response cannot have body message, thus I suggest we could have some BadRequest in few of the scenario below. 

In here I program everything according to the requirements document.
```csharp
using TechnicalAssessment.Core.Exceptions;
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Core.Validators;

namespace TechnicalAssessment.Core.Features.Commands.AddFeature
{
    public class AddFeatureCommandHandler
    {
        private readonly IFeatureRepository _repository;

        public AddFeatureCommandHandler(IFeatureRepository repository)
        {
            _repository = repository;
        }

        public void Handle(AddFeatureCommand command)
        {
            if (!EmailValidator.Validate(command.email))
            {
                throw new NotModifiedException("Email format is invalid.");
            }

            if (string.IsNullOrEmpty(command.featureName))
            {
                throw new NotModifiedException("featureName is empty.");
            }

            if (command.featureName.Length > 500)
            {
                throw new NotModifiedException("featureName is too long.");
            }

            var featureQuery = _repository.Get(command.email, command.featureName);
            if (featureQuery is not null)
            {
                throw new NotModifiedException("Email and feature name already in our database.");
            }

            _repository.Add(command.email, command.featureName, command.enable);
        }

    }
}
```

Database access for feature - FeatureRepository.cs
```csharp
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Persistance;

namespace TechnicalAssessment.Infrastructure.Repositories
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly DatabaseContext _context;

        public FeatureRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Feature? Get(string email, string featureName)
        {
            return _context.Features.FirstOrDefault(x =>
                x.Email == email &&
                x.FeatureName.Name == featureName);
        }

        public void Add(string email, string featureName, bool enabled)
        {
            _context.Features.Add(new Feature
            {
                Email = email,
                FeatureNameId = GetFeatureNameId(featureName),
                Enabled = enabled
            });

            _context.SaveChanges();
        }

        private int GetOrAddFeatureNameId(string featureName)
        {
            var featureNameQuery = _context.FeatureNames.FirstOrDefault(x => x.Name == featureName);
            if (featureNameQuery is null)
            {
                var newFeatureName = _context.FeatureNames.Add(new FeatureName
                {
                    Name = featureName
                });
                _context.SaveChanges();
                return newFeatureName.Entity.Id;
            }

            return featureNameQuery.Id;
        }

    }
}
```

Excluded all async feature for clearer demo purpose.

# Unit tests
Core layer is 100% covered with unit tests

# Integration tests
Infrastructure layer is 100% covered with integration tests done through SQlite in memory database. It not only tests the query but also able to test database schema. 

# Exception handling and logging
This project fully embraces exception propogation for much cleaner code that complies to the DRY principle. Most places should throw to halt the operation with proper http code returned. Ideally, there should be only one try catch handled by Web API server middleware, unless we need to transform the type of exception to another.

# Database migrations
Schema change: Use Presistance project, run: Add-Migration

Apply changes: Use Presentation project, run: Update-Database

(This is because the database credential is the Presentation layer)
