using MediatR;
using SwaggerAPISample.Infrastructure;

namespace SwaggerAPISample.Features.Brand
{
    public class BrandController : ApiControllerBase
    {
        public BrandController(IMediator mediator) : base(mediator)
        {
        }
    }
}