using Solution.Model.Models;

namespace Solution.Domain.Domains
{
    public interface IAuthenticationDomain
    {
        string SignIn(SignInModel signIn);

        void SignOut(long userId);
    }
}
