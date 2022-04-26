using System;
using System.Collections.Generic;
using System.Text;

namespace IFoodyPagamento.Domain.Entities
{
    public class Prato
    {
        public Guid Id { get; set; }
        public Guid IdRestaurante { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double? Valor { get; set; }
        public double? ValorTotal { get; set; }
    }
}
