using System;
using CleanApi.Domain.Common;

namespace CleanApi.Domain
{
    public class ToDoItemId : TypedIdValueBase
    {
        public ToDoItemId(Guid value) : base(value)
        {
        }
    }
}