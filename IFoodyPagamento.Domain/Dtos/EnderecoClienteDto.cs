using System;
using System.Collections.Generic;
using System.Text;

namespace IFoody.Domain.Entities
{
    public class EnderecoClienteDto
    {
        public EnderecoClienteDto(Guid id, Guid idCliente, string primeiraLinhaEnd, string segundaLinhaEnd)
        {
            Id = id;
            IdCliente = idCliente;
            EnderecoLinha1 = primeiraLinhaEnd;
            EnderecoLinha2 = segundaLinhaEnd;
        }

        public Guid Id { get; set; }
        public Guid IdCliente { get; set; }
        public string EnderecoLinha1 { get; set; }
        public string EnderecoLinha2 { get; set; }
        
    }
}
