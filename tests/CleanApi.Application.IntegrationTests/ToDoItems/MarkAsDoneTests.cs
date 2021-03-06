using System;
using System.Threading.Tasks;
using CleanApi.Application.Common.Exceptions;
using CleanApi.Application.IntegrationTests.Common;
using CleanApi.Application.ToDoItems;
using CleanApi.Domain.ToDoItems;
using Xunit;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanApi.Application.IntegrationTests.ToDoItems
{
    [Collection(nameof(SliceFixture))]
    public class MarkAsDoneTests
    {
        private readonly SliceFixture _fixture;

        public MarkAsDoneTests(SliceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldThrowIfToDoDoesNotExists()
        {
            var itemId = new ToDoItemId(Guid.NewGuid());
            Func<Task> act = async () => await _fixture.SendAsync(new MarkAsDoneCommand(itemId));
            
            await act.Should().ThrowAsync<NotFoundException>();
        }

        [Fact]
        public async Task ShouldMarkItemAsDone()
        {
            var todoItem = new ToDoItem("Do this now!","Mark me as done");
            await _fixture.AddAsync(todoItem);

            await _fixture.SendAsync(new MarkAsDoneCommand(todoItem.Id));

            todoItem = await _fixture.FindAsync<ToDoItem, ToDoItemId>(todoItem.Id);
            todoItem.Done.Should().BeTrue(); 
        }
        
        
    }
}