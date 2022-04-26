using IFoody.Domain.Entities;
using IFoodyPagamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFoodyPagamento.Domain.Dtos
{
    public class PedidoGeralDto
    {
        public Guid IdPedidoGeral { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdCartao { get; set; }
    }
}