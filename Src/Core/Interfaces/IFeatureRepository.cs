using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Persistance;

namespace TechnicalAssessment.Core.Interfaces
{
    public interface IFeatureRepository
    {
        public Feature? Get(string email, string featureName);
        public void Add(string email, string featureName, bool enabled);
    }
}
