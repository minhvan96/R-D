using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace SwaggerAPISample.Infrastructure
{
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;

        protected ApiControllerBase(IMediator mediator)
            => _mediator = mediator;
    }
}