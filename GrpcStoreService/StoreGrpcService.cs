using Grpc.Core;
using GrpcBase;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using Grpc.Store.StoreService;
using static Grpc.Store.StoreService.StoreService;

namespace GrpcStore.Grpc {
    public class StoreGrpcService : StoreServiceBase, IGrpcServerService
    {
        protected readonly ILogger<StoreGrpcService> _logger;
        public StoreGrpcService(ILogger<StoreGrpcService> logger)
        {
            _logger = logger;
        }
        public ServerServiceDefinition ToServerServiceDefinition()
        {
            return BindService(this);
        }


        // public async Task<GetKeyValuePairResponse> GetKeyValue(GetKeyValuePairRequest request, ServerCallContext context)
        // {
        //     return new GetKeyValuePairResponse() { Key = 14, Value = 88};
        // }
        public async Task<GetCompaniesResponse> GetCompanies(GetCompaniesRequest request){
            
            return new GetCompaniesResponse();
        }
    }
}
