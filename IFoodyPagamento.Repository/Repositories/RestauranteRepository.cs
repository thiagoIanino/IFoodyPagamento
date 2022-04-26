using Dapper;
using IFoody.Domain.Entities.Restaurantes;
using IFoodyPagamento.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace IFoodyPagamento.Infrastructure.Repositories
{
    public class RestauranteRepository : BaseRepository<Restaurante>, IRestauranteRepository
    {
        public const string BUSCAR_RESTAURANTE_QUERY = "select id,nomeRestaurante,idStripe from Restaurante where id = @id";

        public async Task<Restaurante> BuscarRestaurante(Guid idRestaurante)
        {
            DynamicParameters parms = new DynamicParameters();
            parms.Add("@id", idRestaurante, DbType.Guid);

            return await ObterAsync<Restaurante>(BUSCAR_RESTAURANTE_QUERY, parms);
        } 
    }
}
