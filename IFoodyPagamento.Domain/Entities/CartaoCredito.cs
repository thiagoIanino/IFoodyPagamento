using System;
using System.Collections.Generic;
using System.Text;

namespace IFoodyPagamento.Domain.Entities
{
    public class CartaoCredito
    {
            public CartaoCredito(Guid idCliente,Guid idCartao,string numero, DateTime validade, string nomeTitular, string cpf, string idStripe)
            {
                IdCliente = idCliente;
                IdCartao = idCartao;
                Numero = numero;
                Validade = validade;
                NomeTitular = nomeTitular;
                Cpf = cpf;
                IdStripe = idStripe;
            }

            public Guid IdCliente { get; set; }
            public Guid IdCartao { get; set; }
            public string Numero { get; set; }
            public DateTime Validade { get; set; }
            public string NomeTitular { get; set; }
            public string Cpf { get; set; }
            public string IdStripe { get; set; }

    }
}
