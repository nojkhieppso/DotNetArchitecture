using MongoDB.Driver;

namespace Solution.CrossCutting.MongoDB
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }
    }
}
