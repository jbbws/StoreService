using System;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using DbBase.Interfaces;
namespace DbBase.Core
{
    public class DbContext
    {
        private readonly IMongoDatabase _db;
        public DbContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if(client != null)
                _db = client.GetDatabase(settings.Value.Database);
        }
        public IMongoCollection<BsonDocument> RSBUCodes
        {
            get
            {
                return _db.GetCollection<BsonDocument>("Codes");
            }
        }
        public IMongoCollection<BsonDocument> Companies
        {
            get
            {
                return _db.GetCollection<BsonDocument>("companies");
            }
        }
        public IMongoCollection<BsonDocument> Forms 
        {
            get
            {
                return _db.GetCollection<BsonDocument>("Forms");
            }
        }
    }
}