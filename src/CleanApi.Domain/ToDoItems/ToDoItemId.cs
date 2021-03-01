using System;
using CleanApi.Domain.Common;

namespace CleanApi.Domain.ToDoItems
{
    public class ToDoItemId : TypedIdValueBase
    {
        public ToDoItemId(Guid value) : base(value)
        {
        }
    }
}