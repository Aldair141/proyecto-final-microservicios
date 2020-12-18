using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFORO255.MS.TEST.INVOICE.RabbitMQ.EventHandlers;
using AFORO255.MS.TEST.INVOICE.RabbitMQ.Events;
using AFORO255.MS.TEST.INVOICE.Repository;
using AFORO255.MS.TEST.INVOICE.Repository.Data;
using AFORO255.MS.TEST.INVOICE.Services;
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
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;

namespace AFORO255.MS.TEST.INVOICE
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
                    options.UseNpgsql(Configuration["cnpg"]);
                }
            );

            services.AddScoped<IContextDatabase, ContextDatabase>();
            services.AddScoped<IFacturaServices, FacturaServices>();
            services.AddScoped<IFacturaRepository, FacturaRepository>();

            services.AddMediatR(typeof(Startup));
            services.AddRabbitMQ();
            services.AddTransient<PayEventHandler>();
            services.AddTransient<IEventHandler<PayCreatedEvent>, PayEventHandler>();

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

            MeSuscriboaLaCola(app);

            string serviceID = app.UseConsul();
            hostApplicationLifetime.ApplicationStopped.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(serviceID);
            });
        }

        private void MeSuscriboaLaCola(IApplicationBuilder app)
        {
            IEventBus eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<PayCreatedEvent, PayEventHandler>();
        }
    }
}
