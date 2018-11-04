using Solution.CrossCutting.Utils;
using Solution.Model.Entities;
using Solution.Model.Models;

namespace Solution.Infrastructure.Database
{
    public interface IUserRepository : IRelationalRepository<UserEntity>
    {
        SignedInModel SignIn(SignInModel signIn);
    }
}
