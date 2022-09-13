﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment.Core.Exceptions
{
    public class BadRequestException : Exception, IRestfulException
    {
        public BadRequestException(string? message) : base(message)
        {
        }

        public HttpStatusCode HttpCode => HttpStatusCode.BadRequest;
    }
}