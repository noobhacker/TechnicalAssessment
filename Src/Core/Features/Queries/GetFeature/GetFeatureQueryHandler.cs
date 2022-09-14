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
