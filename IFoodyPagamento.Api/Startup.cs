using IFoodyPagamento.Api.Consumers;
using IFoodyPagamento.Api.Options;
using IFoodyPagamento.Application;
using IFoodyPagamento.Application.Interfaces;
using IFoodyPagamento.CrossCutting.IoC;
using IFoodyPagamento.Domain;
using IFoodyPagamento.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IFoodyPagamento.Api
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

            services.AddCors();

            services.AddDependencyResolver();

            services.AddHostedService<CobrancaConsumer>();

            services.Configure<RabbitMqConfiguration>(Configuration.GetSection("RabbitMqConfig"));

            services.AddHttpClient(Constantes.IFoody.NOME_API_IFOODY, config =>
            {
                config.BaseAddress = new Uri("http://localhost:26373");
                config.DefaultRequestVersion = HttpVersion.Version20;
                config.Timeout = TimeSpan.FromSeconds(30);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin()
            .AllowAnyMethod().
             AllowAnyHeader().
             WithExposedHeaders("Authorization"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
