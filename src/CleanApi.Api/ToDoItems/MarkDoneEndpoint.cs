using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using CleanApi.Application.ToDoItems;
using CleanApi.Domain.ToDoItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanApi.Api.ToDoItems
{
    public class MarkDoneEndpoint:BaseAsyncEndpoint
        .WithRequest<Guid>
        .WithoutResponse
    {
        private readonly IMediator _mediator;

        public MarkDoneEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut("/toDoItems/{id}/done")]
        [SwaggerOperation(
            Summary = "Mark item as done",
            Description = "Mark a to do item as done",
            OperationId = "ToDoItems.MarkAsDone",
            Tags = new[] { "ToDoItems" })
        ]
        public override async Task<ActionResult> HandleAsync(Guid id, CancellationToken cancellationToken = new CancellationToken())
        {
            var todoItemId = new ToDoItemId(id);
            await _mediator.Send(new MarkAsDoneCommand(todoItemId), cancellationToken);
            return Ok();
        }
    }
}