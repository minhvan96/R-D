using IdentityServer.Data.TestData;
using IdentityServer.Shared;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdentityServer.Features.Account.Controllers
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class LdapController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IEventService _events;
        private readonly ILogger<LdapController> _logger;
        private readonly TestUserStore _users;

        public LdapController(
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IEventService events,
            ILogger<LdapController> logger,
            TestUserStore users = null
            )
        {
            _interaction = interaction;
            _clientStore = clientStore;
            _events = events;
            _logger = logger;

            _users = users ?? new TestUserStore(TestUsers.Users);
        }
    }
}