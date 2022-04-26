using System;
using System.Collections.Generic;
using System.Text;

namespace IFoodyPagamento.Domain.Entities
{
    public class Cobranca
    {
        public Cobranca(string idCartaoStripe,Guid idCliente,Guid idRestaurante,double? valor, Guid idPedido)
        {
            Id = Guid.NewGuid();
            IdCartaoStripe = idCartaoStripe;
            IdCliente = idCliente;
            IdRestaurante = idRestaurante;
            Valor = valor;
            IdPedido = idPedido;
        }

        public Guid Id { get; set; }
        public Guid IdPedido { get; set; }
        public string IdCartaoStripe { get; set; }
        public Guid IdCliente { get; set; }
        public Guid IdRestaurante { get; set; }
        public double? Valor { get; set; }
    }
}