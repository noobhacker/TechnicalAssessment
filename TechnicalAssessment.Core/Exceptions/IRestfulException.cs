using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment.Core.Exceptions
{
    public interface IRestfulException
    {
        public HttpStatusCode HttpCode { get; }
    }
}
