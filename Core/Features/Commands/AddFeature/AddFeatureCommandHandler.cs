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
            if(!EmailValidator.Validate(command.email))
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
