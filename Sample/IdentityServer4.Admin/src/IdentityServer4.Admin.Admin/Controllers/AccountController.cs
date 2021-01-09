﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IdentityServer4.Admin.Admin.Configuration.Constants;
using System.Collections.Generic;

namespace IdentityServer4.Admin.Admin.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        public AccountController(ILogger<ConfigurationController> logger) : base(logger)
        {
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return new SignOutResult(new List<string> { AuthenticationConsts.SignInScheme, AuthenticationConsts.OidcAuthenticationScheme });
        }
    }
}





