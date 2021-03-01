using CleanApi.Domain.Common;

namespace CleanApi.Domain
{
    public class ToDoItem:AuditableEntity
    {
        // public ToDoItemId Id { get; set; }
        // public string Title { get; set; }
        // public string Note { get; set; }
        // public bool Done { get; set; }

        private ToDoItemId _id;
        private string _title;
        private string _note;
        private bool _done;

        public static ToDoItem Create(ToDoItemId id, string title, string note)
        {
            var todoitem = new ToDoItem();
            todoitem.DomainEvents
        }
    }
}