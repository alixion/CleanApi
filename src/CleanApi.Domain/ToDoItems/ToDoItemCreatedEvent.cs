using CleanApi.Domain.Common;

namespace CleanApi.Domain.ToDoItems
{
    public class ToDoItemCreatedEvent:DomainEventBase
    {
        public ToDoItemId ToDoItemId { get; }

        public ToDoItemCreatedEvent(ToDoItemId toDoItemId)
        {
            ToDoItemId = toDoItemId;
        }
    }
}