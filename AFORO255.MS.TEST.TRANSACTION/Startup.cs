using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFORO255.MS.TEST.TRANSACTION.RabbitMQ.EventHandlers;
using AFORO255.MS.TEST.TRANSACTION.RabbitMQ.Events;
using AFORO255.MS.TEST.TRANSACTION.Repository;
using AFORO255.MS.TEST.TRANSACTION.Services;
using Consul;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MS.AFORO255.Cross.Consul.Consul;
using MS.AFORO255.Cross.Consul.Mvc;
using MS.AFORO255.Cross.RabbitMQ.Src;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;

namespace AFORO255.MS.TEST.TRANSACTION
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

            services.AddScoped<ITransaccionRepository, TransaccionRepository>();
            services.AddScoped<ITransaccionServices, TransaccionServices>();

            services.AddMediatR(typeof(Startup));
            services.AddRabbitMQ();
            services.AddTransient<TransactionEventHandler>();
            services.AddTransient<IEventHandler<TransactionCreatedEvent>, TransactionEventHandler>();

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

            SuscribirCola(app);

            string serviceID = app.UseConsul();
            hostApplicationLifetime.ApplicationStopped.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(serviceID);
            });
        }

        public void SuscribirCola(IApplicationBuilder app)
        {
            IEventBus bus = app.ApplicationServices.GetRequiredService<IEventBus>();
            bus.Subscribe<TransactionCreatedEvent, TransactionEventHandler>();
        }
    }
}
