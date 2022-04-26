using Dapper;
using IFoodyPagamento.Domain.Entities;
using IFoodyPagamento.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace IFoodyPagamento.Infrastructure.Repositories
{
    public class CobrancaRepository : BaseRepository<Cobranca> , ICobrancaRepository
    {
        public const string GRAVAR_COBRANCA_REPOSITORY = "insert into Cobrancas(id,idCartaoStripe,idCliente,idRestaurante,valor,idPedido) values (@id,@idCartaoStripe,@idCliente,@idRestaurante,@valor,@idPedido)";

        public async Task GravarCobranca(Cobranca cobranca)
        {
            DynamicParameters parms = new DynamicParameters();

            parms.Add("@id", cobranca.Id, DbType.Guid);
            parms.Add("@idCartaoStripe", cobranca.IdCartaoStripe, DbType.AnsiString);
            parms.Add("@idCliente", cobranca.IdCliente, DbType.Guid);
            parms.Add("@idRestaurante", cobranca.IdRestaurante, DbType.Guid);
            parms.Add("@valor", cobranca.Valor, DbType.Double);
            parms.Add("@idPedido", cobranca.IdPedido, DbType.Guid);

            await ExecutarAsync(GRAVAR_COBRANCA_REPOSITORY, parms); 
            
        }
    }
}
