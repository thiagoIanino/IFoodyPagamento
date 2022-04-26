using IFoody.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFoodyPagamento.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> BuscarCliente(Guid id);
    }
}
