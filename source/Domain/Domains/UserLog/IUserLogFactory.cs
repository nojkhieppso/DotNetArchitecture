using Solution.Model.Entities;
using Solution.Model.Enums;

namespace Solution.Domain.Domains
{
    public interface IUserLogFactory
    {
        UserLogEntity Create(long userId, LogType logType);
    }
}
