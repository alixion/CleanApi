using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanApi.Api.Sample
{
    public class SampleEndpoint:BaseAsyncEndpoint
        .WithRequest<string>
        .WithResponse<string>
    {
        private readonly ILogger<SampleEndpoint> _logger;

        public SampleEndpoint(ILogger<SampleEndpoint> logger)
        {
            _logger = logger;
        }
        
        [HttpGet("/hello/{name?}")]
        [SwaggerOperation(
            Summary = "Say Hello",
            Description = "Say Hello",
            OperationId = "Sample.Hello",
            Tags = new[] { "HelloEndpoint" })
        ]
        public override async Task<ActionResult<string>> HandleAsync(string name, CancellationToken cancellationToken = new CancellationToken())
        {
            _logger.LogInformation("Hello {Name}", name);
            name ??= "world";
            return Ok($"Hello {name}");
        }
    }
}