using System;
using System.Collections.Generic;
using System.Text;

namespace IFoodyPagamento.Domain.Dtos
{
    public class RespostaPagamentoDto
    {
        public RespostaPagamentoDto(bool aprovado, Guid idPedido)
        {
            Aprovado = aprovado;
            IdPedido = idPedido;
        }
        public RespostaPagamentoDto(Guid idPedido,string excecao)
        {
            Aprovado = false;
            IdPedido = idPedido;
        }

        public bool Aprovado { get; set; }
        public Guid IdPedido { get; set; }
    }
}
