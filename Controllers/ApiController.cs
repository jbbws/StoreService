using DbBase.Interfaces;
using DbBase.Core;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
namespace StoreService.Controllers
{
    // public class ApiController : Controller
    // {
    //     private readonly IDbRepository _rep;
    //     public ApiController(IDbRepository repository)
    //     {
    //         _rep = repository;
    //     }
    //     [HttpGet("api/{id}")]
    //     public async Task<BsonDocument> GetValue(int id)
    //     {
    //         Console.WriteLine(id);
    //         return  await _rep.GetCompaniesList();
    //     }
    // }
}