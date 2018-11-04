using Solution.CrossCutting.EntityFrameworkCore;
using Solution.Model.Entities;

namespace Solution.Infrastructure.Database
{
    public sealed class UserLogRepository : EntityFrameworkCoreRepository<UserLogEntity>, IUserLogRepository
    {
        public UserLogRepository(DatabaseContext context) : base(context) { }
    }
}
