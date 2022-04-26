using IFoody.Domain.Entities.Restaurantes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFoodyPagamento.Domain.Repositories
{
    public interface IRestauranteRepository
    {
        Task<Restaurante> BuscarRestaurante(Guid idRestaurante);
    }
}
