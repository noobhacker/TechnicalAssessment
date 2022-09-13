using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Persistance;

namespace TechnicalAssessment.Core.UnitTests.Features
{
    public class MockFeatureReturnsNothingRepository : IFeatureRepository
    {
        public void Add(string email, string featureName, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Feature? Get(string email, string featureName)
        {
            return null;
        }

    }
}
