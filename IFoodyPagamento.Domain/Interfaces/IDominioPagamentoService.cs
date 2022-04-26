using IFoody.Domain.Entities;
using IFoodyPagamento.Domain.Dtos;
using IFoodyPagamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFoodyPagamento.Domain.Interfaces
{
    public interface IDominioPagamentoService
    {
        Task<RespostaPagamentoDto> CobrarPedido(CartaoCredito cartao, PedidoGeralDto pedido, Cliente cliente);
    }
}
