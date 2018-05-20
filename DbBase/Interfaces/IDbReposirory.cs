using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
namespace DbBase.Interfaces
{
    public interface IDbRepository
    {
        Task<BsonDocument> GetCompaniesList();
        Task<BsonDocument> GetCompanyById();
        Task<BsonDocument> GetSeries();
    }
}