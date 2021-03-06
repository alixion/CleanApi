﻿using System;
using System.Collections.Generic;

namespace CleanApi.Application.Common.Exceptions
{
    public class InvalidCommandException : ApplicationException
    {
        public List<string> Errors { get; }

        public InvalidCommandException(List<string> errors)
        {
            this.Errors = errors;
        }
    }
}
