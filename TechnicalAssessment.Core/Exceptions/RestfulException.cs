using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
