using System;
using System.Collections.Generic;

namespace CleanApi.Application.Exceptions
{
    public class InvalidCommandException : Exception
    {
        public List<string> Errors { get; }

        public InvalidCommandException(List<string> errors)
        {
            this.Errors = errors;
        }
    }
}
