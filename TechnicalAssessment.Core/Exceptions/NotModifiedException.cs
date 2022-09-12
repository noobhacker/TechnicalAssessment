﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment.Core.Exceptions
{
    public class NotModifiedException : Exception
    {
        public NotModifiedException(string? message) : base(message)
        {
        }
    }
}
