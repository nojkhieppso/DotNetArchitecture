using Solution.CrossCutting.Utils;
using Solution.Model.Entities;

namespace Solution.Infrastructure.Database
{
    public interface IUserLogRepository : IRelationalRepository<UserLogEntity> { }
}
