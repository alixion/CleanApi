using CleanApi.Domain.ToDoItems;

namespace CleanApi.Application.ToDoItems
{
    public class UpdateCommand
    {
        public ToDoItemId Id { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
    }
}