using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
