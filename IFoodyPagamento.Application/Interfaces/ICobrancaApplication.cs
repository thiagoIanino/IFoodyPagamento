using IFoodyPagamento.Application.Models;
using IFoodyPagamento.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFoodyPagamento.Application.Interfaces
{
    public interface ICobrancaApplication
    {
        Task CobrarPedidosCliente(CobrancaInput cobranca);
    }
}
