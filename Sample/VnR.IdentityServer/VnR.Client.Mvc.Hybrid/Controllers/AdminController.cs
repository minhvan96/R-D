﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VnR.IdentityServerAuthorizationService;

namespace VnR.Client.Mvc.Hybrid.Controllers
{
    [Authorize(Policy = "IsAdminRequirementPolicy")]
    public class AdminController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        public AdminController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Admin()
        {
            var requirement = new IsAdminRequirement();
            var resource = new AdminData { Age = 32, Department = "HR" };

            var authorizationResult =
                await _authorizationService.AuthorizeAsync(
                    User, resource, requirement);

            if (authorizationResult.Succeeded)
            {
                return View();
            }
            else
            {
                return new ForbidResult();
            }
        }
    }
}