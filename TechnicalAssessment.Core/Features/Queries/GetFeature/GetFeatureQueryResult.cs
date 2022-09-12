using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Persistance;

namespace TechnicalAssessment.Core.Features.Queries.GetFeature
{
    internal class GetFeatureQueryResult
    {
        public string Email { get; set; }
        public string FeatureName { get; set; }
        public bool Enabled { get; set; }
    }
}
