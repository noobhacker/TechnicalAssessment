using TechnicalAssessment.Core.Exceptions;
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
            try
            {
                _repository.Update(command.email, command.featureName, command.enable);
            }
            catch (EntityException ex)
            {
                throw new NotModifiedException("Failure on updating to database.");
            }
            catch (Exception ex)
            {
                throw new InternalServerException("Server error on updating database.");
            }
        }
    }
}
