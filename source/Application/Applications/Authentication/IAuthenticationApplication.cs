using Solution.Model.Models;

namespace Solution.Application.Applications
{
    public interface IAuthenticationApplication
    {
        string SignIn(SignInModel signIn);

        void SignOut(long userId);
    }
}
