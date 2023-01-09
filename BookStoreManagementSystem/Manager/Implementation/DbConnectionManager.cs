using BookManagement.BusinessModels;
using BookManagement.Managers.Interfaces;
using MongoDB.Driver;
using System;

namespace BookManagement.Managers.Implementation
{
    public class DbConnectionManager : IDbConnectionManager
    {

        private readonly IMongoDatabase _database;

        public DbConnectionManager(IDatabaseSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }
        public IMongoDatabase GetDatabase()
        {
            try
            {
                return _database;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
