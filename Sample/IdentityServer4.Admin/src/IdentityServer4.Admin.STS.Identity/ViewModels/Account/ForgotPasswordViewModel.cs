using IdentityServer4.Admin.STS.Identity.Configuration;
using System.ComponentModel.DataAnnotations;
using IdentityServer4.Admin.Shared.Configuration.Identity;

namespace IdentityServer4.Admin.STS.Identity.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public LoginResolutionPolicy? Policy { get; set; }
        //[Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }
    }
}






