using System.Threading.Tasks;

namespace CleanApi.Domain.ToDoItems
{
    public interface IToDoRepository
    {
        Task<ToDoItem> GetByIdAsync(ToDoItemId id);
        Task AddAsync(ToDoItem item);
    }
}