using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using CleanApi.Application.ToDoItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanApi.Api.ToDoItems
{
    public class CreateToDoEndpoint:BaseAsyncEndpoint
        .WithRequest<CreateToDoCommand>
        .WithResponse<Guid>
    {
        private readonly ILogger<CreateToDoEndpoint> _logger;
        private readonly IMediator _mediator;

        public CreateToDoEndpoint(ILogger<CreateToDoEndpoint> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("/toDoItems")]
        [SwaggerOperation(
            Summary = "Add a new ToDo",
            Description = "Create a new to do item",
            OperationId = "ToDoItems.Create",
            Tags = new[] { "ToDoItems" })
        ]
        public override async Task<ActionResult<Guid>> HandleAsync(CreateToDoCommand request, CancellationToken cancellationToken = new CancellationToken())
        {
            var newItemId = await _mediator.Send(request, cancellationToken);
            return Ok(newItemId);
        }
    }
}