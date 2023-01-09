using MongoDB.Driver;

namespace BookManagement.Managers.Interfaces
{
    public interface IDbConnectionManager
    {
        public IMongoDatabase GetDatabase();
    }
}
