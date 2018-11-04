using Solution.Model.Enums;

namespace Solution.Domain.Domains
{
    public interface IUserLogDomain
    {
        void Save(long userId, LogType logType);
    }
}
