using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using DbBase.Interfaces;
using DbBase.Core;
namespace DbBase.Ioc
{
    public static class Ioc
    {
        public static void AddDbLayer(this IServiceCollection services)
        {
            services.AddSingleton<IDbRepository,MongoRepository>();
        }
    }
}