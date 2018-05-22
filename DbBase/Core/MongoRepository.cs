using DbBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Grpc.Store.StoreService;
using Grpc.Store.StoreService.Base;
namespace DbBase.Core
{
    public class MongoRepository : IDbRepository
    {
        private readonly DbContext _context;
        public MongoRepository(IOptions<Settings> settings)
        {
            _context = new DbContext(settings);
        }
        public async Task<List<BsonDocument>> GetCompaniesList(Company filter, Company projection)
        {
            var fil = new BsonDocument();
            var result = await _context.Companies.Find(fil).ToListAsync();
            return result;
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