using IFoodyPagamento.Application.Interfaces;
using IFoodyPagamento.Application.Models;
using IFoodyPagamento.Domain.Dtos;
using IFoodyPagamento.Domain.Entities;
using IFoodyPagamento.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFoodyPagamento.Application
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IStripeRepository _stripeService;
        public UsuarioApplication(IStripeRepository stripeService)
        {
            _stripeService = stripeService;
        }


        public async Task<UsuarioStripeOutput> CadastrarCliente(UsuarioDto usuario)
        {
            var idUsuario = await _stripeService.CadastrarUsuario(usuario);
            return new UsuarioStripeOutput(idUsuario);
        }

        public async Task<CartaoStripeOutput> CadastrarCartao(CartaoCreditoInput cartao)
        {
            var cartaoCredito = new CartaoCreditoDto(
                cartao.IdStripeCliente,
                cartao.Numero,
                cartao.Validade,
                cartao.NomeTitular,
                cartao.Cpf);

            var idCartao = await _stripeService.CadastrarCartaoCliente(cartaoCredito);
            return new CartaoStripeOutput(idCartao);
        }
    }
}
