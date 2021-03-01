using CleanApi.Domain.ToDoItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanApi.Infrastructure.Data.Configuration
{
    public class ToDoItemConfiguration:IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).IsRequired();
            
            builder.HasIndex(c => c.Title,"IX_to_do_items_title");

        }
    }
}