using System.Net;

namespace TechnicalAssessment.Core.Exceptions
{
    public class BadRequestException : RestfulException
    {
        public BadRequestException(string? message) : base(message)
        {
        }

        public override HttpStatusCode HttpCode => HttpStatusCode.BadRequest;
    }
}
