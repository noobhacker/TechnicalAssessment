using System.Net;

namespace TechnicalAssessment.Core.Exceptions
{
    public abstract class RestfulException : Exception
    {
        protected RestfulException(string? message) : base(message)
        {
        }

        public abstract HttpStatusCode HttpCode { get; }
    }
}
