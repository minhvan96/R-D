﻿using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace VnR.IdentityServerAuthorizationService
{
    public class BobIsAnAdmin : AuthorizationHandler<IsAdminRequirement>
    {
        private readonly IAppAuthorizationService _appAuthorizationService;

        public BobIsAnAdmin(IAppAuthorizationService appAuthorizationService)
        {
            _appAuthorizationService = appAuthorizationService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdminRequirement requirement)
        {
            if (_appAuthorizationService.BobIsAnAdmin(context.User.Identity.Name))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}