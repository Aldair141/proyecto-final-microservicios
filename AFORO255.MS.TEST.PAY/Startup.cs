using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFORO255.MS.TEST.PAY.RabbitMQ.CommandHandlers;
using AFORO255.MS.TEST.PAY.RabbitMQ.Commands;
using AFORO255.MS.TEST.PAY.Repository;
using AFORO255.MS.TEST.PAY.Repository.Data;
using AFORO255.MS.TEST.PAY.Services;
using Consul;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MS.AFORO255.Cross.Consul.Consul;
using MS.AFORO255.Cross.Consul.Mvc;
using MS.AFORO255.Cross.RabbitMQ.Src;

namespace AFORO255.MS.TEST.PAY
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ContextDatabase>(
                options =>
                {
                    options.UseMySQL(Configuration["cnmsql"]);
                }
            );

            services.AddScoped<IContextDatabase, ContextDatabase>();
            services.AddScoped<IOperacionRepository, OperacionRepository>();
            services.AddScoped<IOperacionServices, OperacionServices>();

            services.AddMediatR(typeof(Startup));
            services.AddRabbitMQ();
            services.AddTransient<IRequestHandler<PayCreatedCommand, bool>, PayCommandHandler>();
            services.AddTransient<IRequestHandler<TransactionCreatedCommand, bool>, TransactionCommandHandler>();

            services.AddSingleton<IServiceId, ServiceId>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddConsul();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime hostApplicationLifetime,
            IConsulClient consulClient)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            string serviceID = app.UseConsul();
            hostApplicationLifetime.ApplicationStopped.Register(()=>
            {
                consulClient.Agent.ServiceDeregister(serviceID);
            });
        }
    }
}