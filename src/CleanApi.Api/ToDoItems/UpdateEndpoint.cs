using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using CleanApi.Application.ToDoItems;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanApi.Api.ToDoItems
{
    public class UpdateEndpoint:BaseAsyncEndpoint
        .WithRequest<UpdateCommand>
        .WithoutResponse
        
    {
        [HttpPut("/toDoItems/{id}")]
        [SwaggerOperation(
            Summary = "Mark item as done",
            Description = "Mark a to do item as done",
            OperationId = "ToDoItems.MarkAsDone",
            Tags = new[] { "ToDoItems" })
        ]
        public override Task<ActionResult> HandleAsync(UpdateCommand request, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}