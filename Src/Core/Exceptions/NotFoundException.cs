using System.Net;

namespace TechnicalAssessment.Core.Exceptions
{
    public class NotFoundException : RestfulException
    {
        public NotFoundException(string? message) : base(message)
        {
        }

        public override HttpStatusCode HttpCode => HttpStatusCode.NotFound;
    }
}
