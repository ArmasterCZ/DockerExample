using MongoDB.Driver;

namespace DockerExample.Data
{
    public class MongoDbService
    {
        private readonly IConfiguration config;
        private readonly IMongoDatabase database;

        public MongoDbService(IConfiguration config) 
        {
            this.config = config;
            var connString = this.config.GetConnectionString("DbConnection");
            var mongoUrl = new MongoUrl(connString);
            var mongoClient = new MongoClient(mongoUrl);
            database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        public IMongoDatabase? Database => database;
    }
}
