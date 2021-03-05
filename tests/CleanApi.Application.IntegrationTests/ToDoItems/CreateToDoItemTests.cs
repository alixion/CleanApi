using System.Threading.Tasks;
using CleanApi.Application.IntegrationTests.Common;
using CleanApi.Application.ToDoItems;
using CleanApi.Domain.ToDoItems;
using FluentAssertions;
using Xunit;

namespace CleanApi.Application.IntegrationTests.ToDoItems
{
    [Collection(nameof(SliceFixture))]
    public class CreateToDoItemTests
    {
        private readonly SliceFixture _fixture;

        public CreateToDoItemTests(SliceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldCreateToDoItem()
        {
            var command = new CreateToDoCommand()
            {
                Title = "Test",
                Note = "A to do created from integration tests"
            };

            var itemId = await _fixture.SendAsync(command);

            var todo = await _fixture.FindAsync<ToDoItem, ToDoItemId>(new ToDoItemId(itemId));
            todo.Should().NotBeNull();
            todo.Title.Should().Be("Test");
            itemId.Should().NotBeEmpty();

            await _fixture.RemoveAsync(todo);
        }
        
    }
}