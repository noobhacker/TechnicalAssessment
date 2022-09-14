using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Persistance;

namespace TechnicalAssessment.Core.UnitTests.Features
{
    public class MockReturnsFeatureRepository : IFeatureRepository
    {
        public void Add(string email, string featureName, bool enabled)
        {

        }

        public Feature? Get(string email, string featureName)
        {
            return new Feature
            {
                Email = "testFromDatabase@test.com",
                FeatureName = new FeatureName
                {
                    Id = 1,
                    Name = "FeatureFromDatabase"
                },
                Enabled = true
            };
        }

    }
}
