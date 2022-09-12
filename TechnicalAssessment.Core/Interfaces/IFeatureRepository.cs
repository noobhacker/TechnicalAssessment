using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment.Core.Interfaces
{
    public interface IFeatureRepository
    {
        // if query become complex, declare custom type in Core
        // instead of directly reference to Persistance
        Persistance.Feature? Get(string email, string featureName);
        void Update(Persistance.Feature feature, bool enabled);
    }
}
