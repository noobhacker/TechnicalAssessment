using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Exceptions;
using TechnicalAssessment.Core.Feature.Commands.UpdateFeature;
using TechnicalAssessment.Core.Feature.Queries.GetFeature;
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Persistance;

namespace TechnicalAssessment.Infrastructure.Repositories
{
    internal class FeatureRepository : IFeatureRepository
    {
        private readonly DatabaseContext _context;

        public FeatureRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Feature? Get(string email, string featureName)
        {
            // not found = error, not false, more distict in that way
            var feature = _context.Features.FirstOrDefault(x => 
                x.Email == email && 
                x.FeatureName.Name == featureName);

            return feature;
        }

        public void Update(Feature feature, bool enabled)
        {
            feature.Enabled = enabled;
            _context.SaveChanges();
        }
    }
}
