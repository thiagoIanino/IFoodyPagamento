using Dapper;
using IFoody.Domain.Entities;
using IFoodyPagamento.Domain.Entities;
using IFoodyPagamento.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace IFoodyPagamento.Infrastructure.Repositories
{
    public class ClienteRepository : BaseRepository<CartaoCredito>, IClienteRepository
    {
        const string BUSCAR_CLIENTE_QUERY = "Select id as id,nome as nome,email as email, idStripe as idStripe from Cliente where id = @id";

        public async Task<Cliente> BuscarCliente(Guid id)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@id", id, DbType.Guid);


            return await ObterAsync<Cliente>(BUSCAR_CLIENTE_QUERY, parametros);
        }

    }
}
