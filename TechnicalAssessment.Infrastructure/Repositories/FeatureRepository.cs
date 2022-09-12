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

        public bool GetEnabled(string email, string featureName)
        {
            var feature = _context.Features.FirstOrDefault(x =>
                x.Email == email &&
                x.FeatureName.Name == featureName);

            if (feature is null)
            {
                throw new NotFoundException("Email or feature name not found in our database.");
            }

            return feature.Enabled;
        }

        public void Update(string email, string featureName, bool enabled)
        {
            var feature = _context.Features.FirstOrDefault(x =>
                x.Email == email &&
                x.FeatureName.Name == featureName);

            if (feature is null)
            {
                throw new NotFoundException("Email or feature name not found in our database");
            }

            feature.Enabled = enabled;
            _context.SaveChanges();
        }
    }
}
