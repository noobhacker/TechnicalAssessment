using TechnicalAssessment.Core.Exceptions;
using TechnicalAssessment.Core.Features.Validators;
using TechnicalAssessment.Core.Interfaces;

namespace TechnicalAssessment.Core.Features.Commands.UpdateFeature
{
    public class UpdateFeatureCommandHandler
    {
        private readonly IFeatureRepository _repository;

        public UpdateFeatureCommandHandler(IFeatureRepository repository)
        {
            _repository = repository;
        }

        public void Handle(UpdateFeatureCommand command)
        {
            EmailValidator.Validate(command.email);
            FeatureNameValidator.Validate(command.featureName);

            var featureQuery = _repository.Get(command.email, command.featureName);
            if (featureQuery is not null)
            {
                throw new NotModifiedException("Email and feature name already in our database.");
            }

            _repository.Add(command.email, command.featureName, command.enable);
        }
      
    }
}
