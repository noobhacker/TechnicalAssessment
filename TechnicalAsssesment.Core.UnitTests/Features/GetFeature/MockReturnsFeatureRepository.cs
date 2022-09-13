using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Persistance;

namespace Core.UnitTests.Features.GetFeature
{
    public class MockReturnsFeatureRepository : IFeatureRepository
    {
        public void Add(string email, string featureName, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Feature? Get(string email, string featureName)
        {
            return new Feature
            {
                Email = "test@test.com",
                FeatureName = new FeatureName
                {
                    Id = 1,
                    Name = "Feature1"
                },
                Enabled = true
            };
        }

    }
}
