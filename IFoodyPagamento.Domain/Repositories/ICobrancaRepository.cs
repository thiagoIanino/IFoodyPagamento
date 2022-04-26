using IFoodyPagamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFoodyPagamento.Domain.Repositories
{
    public interface ICobrancaRepository
    {
        Task GravarCobranca(Cobranca cobranca);
    }
}
