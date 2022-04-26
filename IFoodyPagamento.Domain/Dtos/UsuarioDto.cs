using IFoodyPagamento.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFoodyPagamento.Domain.Dtos
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Categoria Categoria { get; set; }
    }
}