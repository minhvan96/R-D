//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;

//namespace IdentityServer.Shared
//{
//    public class IdentityControllerBase : Controller
//    {
//        private readonly IMediator _mediator;

//        public IdentityControllerBase(IMediator mediator)
//        {
//            _mediator = mediator;
//        }

//        protected async Task<IActionResult> HandleRequest<T>(IRequest<string> request)
//        {
//            if (!ModelState.IsValid)
//            {
//            }

//            var returnUrl = await _mediator.Send(request);

//            return Redirect(returnUrl);
//        }
//    }
//}