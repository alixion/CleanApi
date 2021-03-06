using System.Threading.Tasks;
using CleanApi.Domain.ToDoItems;
using Microsoft.EntityFrameworkCore;

namespace CleanApi.Infrastructure.Data.EfRepositories
{
    public class ToDoRepository:IToDoRepository
    {
        private readonly CleanApiContext _context;

        public ToDoRepository(CleanApiContext context)
        {
            _context = context;
        }
        public async Task<ToDoItem> GetByIdAsync(ToDoItemId id)
        {
            return await _context.ToDoItems.FindAsync(id);
        }

        public async Task AddAsync(ToDoItem item)
        {
            await _context.AddAsync(item);
        }
    }
}