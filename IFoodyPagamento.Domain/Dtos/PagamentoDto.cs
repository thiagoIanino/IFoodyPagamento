using IFoodyPagamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFoodyPagamento.Domain.Dtos
{
    public class PagamentoDto
    {
        public PagamentoDto(CartaoCredito cartao, PedidoGeralDto pedido)
        {
            NumeroCartao = cartao.Numero;
            Mes = cartao.Validade.Month;
            Ano = cartao.Validade.Year;
            Valor = (int)pedido.Pedidos.First().ValorTotal * 100;
        }
        public string NumeroCartao { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int Valor { get; set; }
        public Guid IdPedido { get; set; }

    }
}
