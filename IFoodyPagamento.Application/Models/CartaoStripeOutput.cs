using System;
using System.Collections.Generic;
using System.Text;

namespace IFoodyPagamento.Application.Models
{
    public class CartaoStripeOutput
    {
        public CartaoStripeOutput(string id)
        {
            IdCartaoStripe = id;
        }
        public string IdCartaoStripe { get; set; }
    }
}
