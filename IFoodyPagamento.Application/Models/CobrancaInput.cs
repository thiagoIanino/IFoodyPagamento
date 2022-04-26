using IFoodyPagamento.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFoodyPagamento.Application.Models
{
    public class CobrancaInput
    {
        public PedidoGeralDto PedidoGeral { get; set; }
        public string TokenAutenticacao { get; set; }
    }
}
