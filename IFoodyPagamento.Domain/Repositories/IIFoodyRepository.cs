using IFoodyPagamento.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFoodyPagamento.Domain.Repositories
{
    public interface IIFoodyRepository
    {
        Task ConfirmarPagamento(ConfirmacaoPagamentoDto confirmacaoPedido, string tokenAutenticacao);
    }
}
