using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment.Core.Interfaces
{
    public interface IFeatureRepository
    {
        bool GetEnabled(string email, string featureName);
        void Update(string email, string featureName, bool enabled);
    }
}
