using System;
using System.Collections.Generic;
using System.Text;

namespace IFoodyPagamento.Domain.Dtos
{
    public class ConfirmacaoPagamentoDto
    {
        public PedidoGeralDto PedidoGeral { get; set; }
        public RespostaPagamentoDto RespostaPagamento { get; set; }
    }
}
