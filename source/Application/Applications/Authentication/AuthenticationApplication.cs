using Solution.Domain.Domains;
using Solution.Model.Models;

namespace Solution.Application.Applications
{
    public sealed class AuthenticationApplication : IAuthenticationApplication
    {
        public AuthenticationApplication(IAuthenticationDomain authenticationDomain)
        {
            AuthenticationDomain = authenticationDomain;
        }

        private IAuthenticationDomain AuthenticationDomain { get; }

        public string SignIn(SignInModel signIn)
        {
            return AuthenticationDomain.SignIn(signIn);
        }

        public void SignOut(long userId)
        {
            AuthenticationDomain.SignOut(userId);
        }
    }
}
