using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Exceptions;

namespace TechnicalAssessment.Core.Features.Validators
{
    public static class EmailValidator
    {
        public static void Validate(string email)
        {
            try
            {
                new EmailAddressAttribute().IsValid(email);
            }
            catch
            {
                throw new BadRequestException($"Email is in invalid format: {email}");
            }
        }
    }
}
