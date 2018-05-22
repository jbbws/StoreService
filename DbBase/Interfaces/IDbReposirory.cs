using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Grpc.Store.StoreService;
using Grpc.Store.StoreService.Base;
namespace DbBase.Interfaces
{
    public interface IDbRepository
    {
        Task<List<BsonDocument>> GetCompaniesList(Company filter, Company projection);
        Task<BsonDocument> GetCompanyById();
        Task<BsonDocument> GetSeries();
    }
}