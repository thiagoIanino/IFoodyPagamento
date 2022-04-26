using IFoody.Domain.Entities;
using IFoodyPagamento.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFoodyPagamento.Domain.Entities
{
    public class Pedido
    {
        public Guid IdPedido { get; set; }
        public Guid IdRestaurante { get; set; }
        public string NomeRestaurante { get; set; }
        public string UrlImagemRestaurante { get; set; }
        public DateTime TempoPrevistoEntrega { get; set; }
        public Guid IdCliente { get; set; }
        public List<Prato> Itens { get; set; }
        public double? ValorTotal { get; set; }
        public StatusPedido Status { get; set; }
        public EnderecoClienteDto EnderecoCliente { get; set; }

    }
}
