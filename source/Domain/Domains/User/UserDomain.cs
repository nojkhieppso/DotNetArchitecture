using Solution.CrossCutting.Utils;
using Solution.Infrastructure.Database;
using Solution.Model.Models;
using System.Collections.Generic;

namespace Solution.Domain.Domains
{
    public sealed class UserDomain : IUserDomain
    {
        public UserDomain(IDatabaseUnitOfWork databaseUnitOfWork)
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        public PagedList<UserModel> List(PagedListParameters parameters)
        {
            return DatabaseUnitOfWork.UserRepository.List<UserModel>(parameters);
        }

        public IEnumerable<UserModel> List()
        {
            return DatabaseUnitOfWork.UserRepository.List<UserModel>();
        }

        public UserModel Select(long userId)
        {
            return DatabaseUnitOfWork.UserRepository.Select<UserModel>(userId);
        }
    }
}
