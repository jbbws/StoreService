using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GrpcStore.Grpc;
using GrpcBase;
using DbBase.Core;
using DbBase.Ioc;
namespace StoreService
{
    public class Startup
    {
        private IGrpcServer _grpcServer;
        private const string GrpcUrl = @"GrpcApi";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Configure<Settings>(options=>
            {
                options.ConnectionString ="mongodb://localhost"; //Configuration.GetSection("MongoConnection:MongoConnection").Value;
                options.Database = "findocs";//Configuration.GetSection("MongoConnection:Database").Value;
            });
            services.AddDbLayer();
            services.AddGrpc(Configuration.GetValue<Uri>(GrpcUrl));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IGrpcServer grpcServer,IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc();
            _grpcServer = grpcServer;
            applicationLifetime.ApplicationStarted.Register(_grpcServer.Start);
            applicationLifetime.ApplicationStopped.Register(_grpcServer.Stop);
        }
    }
}
