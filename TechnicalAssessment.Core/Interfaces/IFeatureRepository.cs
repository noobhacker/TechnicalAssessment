using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Feature.Commands.UpdateFeature;
using TechnicalAssessment.Core.Feature.Queries.GetFeature;

namespace TechnicalAssessment.Core.Interfaces
{
    interface IFeatureRepository
    {
        GetFeatureResponse Get(GetFeatureQuery query);
        void Update(UpdateFeatureCommand command);
    }
}
