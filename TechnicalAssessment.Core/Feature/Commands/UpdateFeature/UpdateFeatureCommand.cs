using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment.Core.Feature.Commands.UpdateFeature
{
    internal class UpdateFeatureCommand
    {
        public string featureName { get; set; }
        public string email { get; set; }
        public bool enable { get; set; }
    }
}
