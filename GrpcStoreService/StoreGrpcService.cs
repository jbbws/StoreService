using Grpc.Core;
using GrpcBase;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using Grpc.Store.StoreService;
using Grpc.Store.StoreService.Base;
using static Grpc.Store.StoreService.StoreService;
using DbBase.Interfaces;
using Google.Protobuf;
namespace StoreService.Grpc {
    public class StoreGrpcService : StoreServiceBase, IGrpcServerService
    {
        protected readonly ILogger<StoreGrpcService> _logger;
        protected readonly IDbRepository _repository;
        public StoreGrpcService(ILogger<StoreGrpcService> logger,IDbRepository rep)
        {
            _logger = logger;
            _repository = rep;
        }
        public ServerServiceDefinition ToServerServiceDefinition()
        {
            return BindService(this);
        }

        public override async Task<GetCompaniesResponse> GetCompanies(CompanySearch request,ServerCallContext context){
            var response = new GetCompaniesResponse();
            var result =  _repository.GetCompaniesList(request.Filter, request.Projection);
            result.Result.ForEach(x =>response.Org.Add(new Company(){Id = x["code"].AsInt32, Name = x["name"].AsString}));
            return response;
        }
    }
}
