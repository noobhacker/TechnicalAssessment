﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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