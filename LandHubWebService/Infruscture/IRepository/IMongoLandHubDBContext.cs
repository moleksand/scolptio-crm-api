using MongoDB.Driver;

namespace Services.Repository
{
    public interface IMongoLandHubDBContext
    {
        IMongoCollection<User> GetCollection<User>(string name);
    }
}
