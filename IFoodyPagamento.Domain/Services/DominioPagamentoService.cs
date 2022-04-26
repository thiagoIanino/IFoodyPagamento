using IFoody.Domain.Entities;
using IFoodyPagamento.Domain.Dtos;
using IFoodyPagamento.Domain.Entities;
using IFoodyPagamento.Domain.Interfaces;
using IFoodyPagamento.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace IFoodyPagamento.Domain.Services
{
    public class DominioPagamentoService : IDominioPagamentoService
    {
        private readonly IStripeRepository _stripeService;
        private readonly IRestauranteRepository _restauranteService;
        private readonly ICobrancaRepository _cobrancaService;
        public DominioPagamentoService(IStripeRepository stripeService, IRestauranteRepository restauranteService, ICobrancaRepository cobrancaService)
        {
            _stripeService = stripeService;
            _restauranteService = restauranteService;
            _cobrancaService = cobrancaService;
        }

        public async Task<RespostaPagamentoDto> CobrarPedido(CartaoCredito cartao, PedidoGeralDto pedidoGeral, Cliente cliente)
        {
            var idsPagamentos = new List<string>();

            try
            {
                using (var transacao = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    foreach (var pedido in pedidoGeral.Pedidos)
                    {
                        var restaurante = await _restauranteService.BuscarRestaurante(pedido.IdRestaurante);

                        var idPagamento = await _stripeService.PagarAsync(cartao, cliente.IdStripe, pedido);
                        idsPagamentos.Add(idPagamento);

                        var cobranca = new Cobranca(cartao.IdStripe,cliente.Id,pedido.IdRestaurante,pedido.ValorTotal, pedidoGeral.IdPedidoGeral);

                        await _cobrancaService.GravarCobranca(cobranca);
                    }

                    await ConfirmarPagamentos(idsPagamentos);
                    transacao.Complete();
                }
            }catch (Exception ex)
            {
                return new RespostaPagamentoDto(pedidoGeral.IdPedidoGeral,ex.Message);
            }

            return new RespostaPagamentoDto(true, pedidoGeral.IdPedidoGeral);
        }

        private async Task ConfirmarPagamentos(List<string> idspagamentos)
        {
            foreach(var id in idspagamentos)
            {
               await _stripeService.ConfirmarPagamento(id);
            }
        }

    }
}
