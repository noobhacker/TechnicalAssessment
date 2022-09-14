using System.Net;

namespace TechnicalAssessment.Core.Exceptions
{
    public class NotModifiedException : RestfulException
    {
        public NotModifiedException(string? message) : base(message)
        {
        }

        public override HttpStatusCode HttpCode => HttpStatusCode.NotModified;
    }
}
