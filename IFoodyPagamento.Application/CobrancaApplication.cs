using IFoodyPagamento.Application.Interfaces;
using IFoodyPagamento.Application.Models;
using IFoodyPagamento.Domain.Dtos;
using IFoodyPagamento.Domain.Interfaces;
using IFoodyPagamento.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFoodyPagamento.Application
{
    public class CobrancaApplication : ICobrancaApplication
    {
        private readonly ICartaoRepository _cartaoService;
        private readonly IDominioPagamentoService _dominioPagamentoService;
        private readonly IIFoodyRepository _ifoodyService;
        private readonly IClienteRepository _clienteService;

        public CobrancaApplication(ICartaoRepository cartaoService, IDominioPagamentoService dominioPagamentoService, IIFoodyRepository ifoodyService, IClienteRepository clienteService)
        {
            _cartaoService = cartaoService;
            _dominioPagamentoService = dominioPagamentoService;
            _ifoodyService = ifoodyService;
            _clienteService = clienteService;
        }

        public async Task CobrarPedidosCliente(CobrancaInput cobranca)
        {
            var cartao = await _cartaoService.ObterCartaoCliente(cobranca.PedidoGeral.IdCartao);

            var cliente = await _clienteService.BuscarCliente(cobranca.PedidoGeral.IdUsuario);

            var pagamento = await _dominioPagamentoService.CobrarPedido(cartao,cobranca.PedidoGeral, cliente);

            var confirmacaoPedido = new ConfirmacaoPagamentoDto
            {
                PedidoGeral = cobranca.PedidoGeral,
                RespostaPagamento = pagamento
            };

            _ = _ifoodyService.ConfirmarPagamento(confirmacaoPedido,cobranca.TokenAutenticacao);
        }
    }
}
