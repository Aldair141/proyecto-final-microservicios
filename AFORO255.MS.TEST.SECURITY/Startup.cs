using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFORO255.MS.TEST.SECURITY.Repository;
using AFORO255.MS.TEST.SECURITY.Repository.Data;
using AFORO255.MS.TEST.SECURITY.Services;
using Consul;
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
using MS.AFORO255.Cross.Jwt.Src;

namespace AFORO255.MS.TEST.SECURITY
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
            services.AddJwtCustomized();
            services.Configure<JwtOptions>(Configuration.GetSection("jwt"));

            services.AddControllers();

            services.AddDbContext<ContextDatabase>(
                options =>
                {
                    options.UseSqlServer(Configuration["cnsql"]);
                }
            );

            services.AddScoped<IContextDatabase, ContextDatabase>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioServices, UsuarioServices>();

            services.AddSingleton<IServiceId, ServiceId>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddConsul();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime tiempoVida,
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
            tiempoVida.ApplicationStopped.Register(()=>
            {
                consulClient.Agent.ServiceDeregister(serviceID);
            });
        }
    }
}
