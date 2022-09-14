using System.ComponentModel.DataAnnotations;

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
