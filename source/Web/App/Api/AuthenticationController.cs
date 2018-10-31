using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.Application.Applications;
using Solution.CrossCutting.AspNetCore.Attributes;
using Solution.CrossCutting.Utils;
using Solution.Model.Models;

namespace Solution.Web.App
{
    [ApiController]
    [RouteController]
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationController(IAuthenticationApplication authenticationApplication)
        {
            AuthenticationApplication = authenticationApplication;
        }

        private IAuthenticationApplication AuthenticationApplication { get; }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public string SignIn(SignInModel signIn)
        {
            return AuthenticationApplication.SignIn(signIn);
        }

        [HttpPost("[action]")]
        public void SignOut()
        {
            AuthenticationApplication.SignOut(User.AuthenticatedUserId());
        }
    }
}
