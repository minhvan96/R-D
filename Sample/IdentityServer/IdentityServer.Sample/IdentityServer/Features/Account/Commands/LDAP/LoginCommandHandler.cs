//using IdentityServer.Features.Account.Options;
//using IdentityServer.LdapExtension.UserModel;
//using IdentityServer.LdapExtension.UserStore;
//using IdentityServer4;
//using IdentityServer4.Events;
//using IdentityServer4.Models;
//using IdentityServer4.Services;
//using IdentityServer4.Stores;
//using MediatR;
//using Microsoft.AspNetCore.Authentication;
//using System;
//using System.Security.Policy;
//using System.Threading;
//using System.Threading.Tasks;

//namespace IdentityServer.Features.Account.Commands.LDAP
//{
//    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
//    {
//        private readonly IIdentityServerInteractionService _interaction;
//        private readonly IClientStore _clientStore;
//        private readonly IAuthenticationSchemeProvider _schemeProvider;
//        private readonly ILdapUserStore _userStore;
//        private readonly IEventService _events;

//        public LoginCommandHandler(
//            IIdentityServerInteractionService interaction,
//            IClientStore clientStore,
//            IAuthenticationSchemeProvider schemeProvider,
//            ILdapUserStore userStore,
//            IEventService events
//            )
//        {
//            _interaction = interaction;
//            _clientStore = clientStore;
//            _schemeProvider = schemeProvider;
//            _userStore = userStore;
//            _events = events;
//        }

//        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
//        {
//            if (request.Button != "login")
//            {
//                // the user clicked the "cancel" button
//                var context = await _interaction.GetAuthorizationContextAsync(request.Model.ReturnUrl);
//                if (context != null)
//                {
//                    await _interaction.DenyAuthorizationAsync(context, AuthorizationError.AccessDenied);

//                    // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
//                    //if (context.IsNativeClient())
//                    //{
//                    //    // The client is native, so this change in how to
//                    //    // return the response is for better UX for the end user.
//                    //    return this.LoadingPage("Redirect", request.Model.ReturnUrl);
//                    //}

//                    return request.Model.ReturnUrl;
//                }
//                else
//                {
//                    // since we don't have a valid context, then we just go back to the home page
//                    return "~/";
//                }
//            }

//            // validate username/password against Ldap
//            var user = _userStore.ValidateCredentials(request.Model.Username, request.Model.Password);

//            // In case you have multiple domain entry, you can also choose to do that.
//            // also, don't forget to uncomment the line 33+ in Login.cshtml
//            //var user = _userStore.ValidateCredentials(model.Username, model.Password, model.Domain);
//            if (user != default(IAppUser))
//            {
//                await _events.RaiseAsync(new UserLoginSuccessEvent(user.Username, user.SubjectId, user.Username));

//                // only set explicit expiration here if user chooses "remember me".
//                // otherwise we rely upon expiration configured in cookie middleware.
//                AuthenticationProperties props = null;
//                if (AccountOptions.AllowRememberLogin && request.Model.RememberLogin)
//                {
//                    props = new AuthenticationProperties
//                    {
//                        IsPersistent = true,
//                        ExpiresUtc = DateTimeOffset.UtcNow.Add(AccountOptions.RememberMeLoginDuration)
//                    };
//                }

//                // issue authentication cookie with subject ID and username
//                var isuser = new IdentityServerUser(user.SubjectId)
//                {
//                    DisplayName = user.Username
//                };

//                // issue authentication cookie with subject ID and username
//                //await HttpContext.SignInAsync(isuser, props);

//                // make sure the returnUrl is still valid, and if so redirect back to authorize endpoint or a local page
//                //if (_interaction.IsValidReturnUrl(request.Model.ReturnUrl) || Url.IsLocalUrl(request.Model.ReturnUrl))
//                //{
//                //    return request.Model.ReturnUrl;
//                //}

//                return "~/";
//            }

//            await _events.RaiseAsync(new UserLoginFailureEvent(request.Model.Username, "invalid credentials"));
//            return "";
//        }
//    }
//}