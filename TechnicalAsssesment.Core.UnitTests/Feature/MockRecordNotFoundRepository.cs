using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Interfaces;

namespace TechnicalAsssesment.Core.UnitTests.Feature
{
    public class MockRecordNotFoundRepository : IFeatureRepository
    {
        public TechnicalAssessment.Persistance.Feature? Get(string email, string featureName)
        {
            return null;
        }

        public void Update(TechnicalAssessment.Persistance.Feature feature, bool enabled)
        {
            throw new EntityException();
        }
    }
}
