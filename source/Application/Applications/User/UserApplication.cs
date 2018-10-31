using Solution.CrossCutting.Utils;
using Solution.Domain.Domains;
using Solution.Model.Models;
using System.Collections.Generic;

namespace Solution.Application.Applications
{
    public sealed class UserApplication : IUserApplication
    {
        public UserApplication(IUserDomain userDomain)
        {
            UserDomain = userDomain;
        }

        private IUserDomain UserDomain { get; }

        public PagedList<UserModel> List(PagedListParameters parameters)
        {
            return UserDomain.List(parameters);
        }

        public IEnumerable<UserModel> List()
        {
            return UserDomain.List();
        }

        public UserModel Select(long userId)
        {
            return UserDomain.Select(userId);
        }
    }
}
