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
        bool GetEnabled(string email, string featureName);
        void Update(string email, string featureName, bool enabled);
    }
}
