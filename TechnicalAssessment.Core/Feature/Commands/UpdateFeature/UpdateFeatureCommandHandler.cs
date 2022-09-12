using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Exceptions;
using TechnicalAssessment.Core.Interfaces;

namespace TechnicalAssessment.Core.Feature.Commands.UpdateFeature
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

            _repository.Update(feature, command.enable);
        }
    }
}
