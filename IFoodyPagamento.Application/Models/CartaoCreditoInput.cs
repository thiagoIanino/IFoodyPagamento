﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IFoodyPagamento.Application.Models
{
    public class CartaoCreditoInput
    {
        public string IdStripeCliente { get; set; }
        public string Numero { get; set; }
        public DateTime Validade { get; set; }
        public string NomeTitular { get; set; }
        public string Cpf { get; set; }
    }
}
