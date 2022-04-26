using System;
using System.Collections.Generic;
using System.Text;

namespace IFoodyPagamento.Application.Models
{
    public class UsuarioStripeOutput
    {
        public UsuarioStripeOutput(string idUsuario)
        {
            IdUsuario = idUsuario;
        }
        public string IdUsuario { get; set; }
    }
}
