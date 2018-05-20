using DbBase.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
namespace DbBase.Core
{
    public class MongoRepository : IDbRepository
    {
        private readonly DbContext _context;
        public MongoRepository(IOptions<Settings> settings)
        {
            _context = new DbContext(settings);
        }
        public async Task<BsonDocument> GetCompaniesList()
        {
            return   await _context.Companies.Find(new BsonDocument()).FirstOrDefaultAsync();
        }
        public  async Task<BsonDocument> GetSeries()
        {
            return  await  _context.Companies.Find(new BsonDocument()).FirstOrDefaultAsync();
        }
        public async Task<BsonDocument> GetCompanyById()
        {
            return await  _context.Companies.Find(new BsonDocument()).FirstOrDefaultAsync();
        }
    }
}