using Microsoft.Extensions.Options;
using MongoDB.Driver;
using CheckListBuild_BE.Configs;

namespace CheckListBuild_BE.Database
{
    public class ApplicationDbContext
    {
        public IMongoDatabase Database { get; }
        private readonly IMongoDatabase _database;

        public ApplicationDbContext(IOptions<CheckListConfiguration> checkListConfig)
        {
            var client = new MongoClient(checkListConfig.Value.ConnectionString);
            _database = client.GetDatabase(checkListConfig.Value.DatabaseName);
            Database = _database;
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }

      
    }
}
