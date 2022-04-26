using IFoodyPagamento.Application;
using IFoodyPagamento.Application.Interfaces;
using IFoodyPagamento.Domain.Interfaces;
using IFoodyPagamento.Domain.Repositories;
using IFoodyPagamento.Domain.Services;
using IFoodyPagamento.Infrastructure.Repositories;
using IFoodyPagamento.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFoodyPagamento.CrossCutting.IoC
{
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            services.AddScoped<ICobrancaApplication, CobrancaApplication>();
            services.AddScoped<ICartaoRepository, CartaoRepository>();
            services.AddScoped<IStripeRepository, StripeRepository>();
            services.AddScoped<IDominioPagamentoService, DominioPagamentoService>();
            services.AddScoped<IUsuarioApplication, UsuarioApplication>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IRestauranteRepository, RestauranteRepository>();
            services.AddScoped<ICobrancaRepository, CobrancaRepository>();
            services.AddScoped<IIFoodyRepository, IFoodyRepository>();
        }

    }
}
