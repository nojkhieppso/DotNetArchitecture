using MongoDB.Bson;

namespace Solution.CrossCutting.MongoDB
{
    public interface IDocument
    {
        ObjectId Id { get; set; }
    }
}
