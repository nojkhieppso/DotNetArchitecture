using Solution.Infrastructure.Database;
using Solution.Model.Enums;

namespace Solution.Domain.Domains
{
    public sealed class UserLogDomain : IUserLogDomain
    {
        public UserLogDomain(
            IDatabaseUnitOfWork databaseUnitOfWork,
            IUserLogFactory userLogFactory)
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            UserLogFactory = userLogFactory;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }
        private IUserLogFactory UserLogFactory { get; }

        public void Save(long userId, LogType logType)
        {
            var userLog = UserLogFactory.Create(userId, logType);
            DatabaseUnitOfWork.UserLogRepository.Add(userLog);
            DatabaseUnitOfWork.SaveChanges();
        }
    }
}
