using System;

namespace CleanApi.Application.Common.Exceptions
{
    public class NotFoundException:ApplicationException
    {
        public NotFoundException(string name, object key)
            : base($"Could not find {name} with id {key}.")
        {
        }
    }
}