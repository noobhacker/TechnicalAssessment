using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Exceptions;
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Persistance;

namespace TechnicalAssessment.Infrastructure.Repositories
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly DatabaseContext _context;

        public FeatureRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Feature? Get(string email, string featureName)
        {
            return _context.Features.FirstOrDefault(x =>
                x.Email == email &&
                x.FeatureName.Name == featureName);
        }

        public void Add(string email, string featureName, bool enabled)
        {
            _context.Features.Add(new Feature
            {
                Email = email,
                FeatureNameId = GetFeatureNameId(featureName),
                Enabled = enabled
            });

            _context.SaveChanges();
        }

        private int GetFeatureNameId(string featureName)
        {
            var featureNameQuery = _context.FeatureNames.FirstOrDefault(x => x.Name == featureName);
            if (featureNameQuery is null)
            {
                var newFeatureName = _context.FeatureNames.Add(new FeatureName
                {
                    Name = featureName
                });
                _context.SaveChanges();
                return newFeatureName.Entity.Id;
            }

            return featureNameQuery.Id;
        }

    }
}
