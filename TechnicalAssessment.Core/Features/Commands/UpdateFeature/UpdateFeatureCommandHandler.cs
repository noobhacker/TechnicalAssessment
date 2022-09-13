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

            _repository.Update(command.email, command.featureName, command.enable);
        }
    }
}
