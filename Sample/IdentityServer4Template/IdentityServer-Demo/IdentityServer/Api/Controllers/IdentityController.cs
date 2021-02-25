using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("identity")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        private readonly IHttpContextAccessor _accessor;

        public IdentityController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public async Task<IActionResult> Get()
        {
            var test = _accessor.HttpContext;
            var result = await _accessor.HttpContext.AuthenticateAsync();

            var properties = result.Properties.Items;
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}