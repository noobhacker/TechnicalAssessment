using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Exceptions;

namespace TechnicalAssessment.Core.Features.Validators
{
    public static class FeatureNameValidator
    {
        public static void Validate(string featureName)
        {
            if(string.IsNullOrEmpty(featureName))
            {
                throw new BadRequestException("featureName is empty.");
            }

            if(featureName.Length > 500)
            {
                throw new BadRequestException("featureName is too long.");
            }
        }
    }
}
