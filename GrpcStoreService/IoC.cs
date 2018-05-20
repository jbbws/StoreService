using System;
using GrpcBase;
using Microsoft.Extensions.DependencyInjection;
using GrpcStore.Grpc;

namespace GrpcStore.Grpc {
    public static class IoC 
    {
        public static IServiceCollection AddGrpc(this IServiceCollection services, Uri grpcUrl)
        {
            services.Configure<GrpcServerOptions>((o)=>o.ListenAddress = grpcUrl);
            services.AddTransient<IGrpcServerService,StoreGrpcService>();
            services.AddSingleton<IGrpcServer,GrpcServer>();
            return services;
        } 
    }
}