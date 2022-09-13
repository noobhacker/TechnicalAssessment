using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Exceptions;

namespace TechnicalAssessment.Core.Validators
{
    public static class EmailValidator
    {
        public static bool Validate(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
