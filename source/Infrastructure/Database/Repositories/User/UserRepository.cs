using Solution.CrossCutting.EntityFrameworkCore;
using Solution.Model.Entities;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Infrastructure.Database
{
    public sealed class UserRepository : EntityFrameworkCoreRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context) { }

        public SignedInModel SignIn(SignInModel signIn)
        {
            return SingleOrDefault<SignedInModel>
            (
                user => user.Login.Equals(signIn.Login)
                && user.Password.Equals(signIn.Password)
                && user.Status == Status.Active
            );
        }
    }
}
