using CleanApi.Domain.ToDoItems;
using Microsoft.EntityFrameworkCore;

namespace CleanApi.Infrastructure.Data
{
    public class CleanApiContext:DbContext
    {
        public CleanApiContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanApiContext).Assembly);
        }
    }
}