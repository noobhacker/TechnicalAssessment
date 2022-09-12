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
            var feature = _repository.Get(command.email, command.featureName);
            if (feature == null)
            {
                throw new NotModifiedException("Feature not found in our database.");
            }

            try
            {
                _repository.Update(feature, command.enable);
            }
            catch (EntityException ex)
            {
                // _logger.log
                throw new NotModifiedException("Failure on updating to database.");
            }
            catch (Exception ex)
            {
                throw new InternalServerException("Server error on updating database.");
            }
        }
    }
}
