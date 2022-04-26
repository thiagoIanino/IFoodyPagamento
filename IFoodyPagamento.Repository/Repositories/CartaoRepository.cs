using Dapper;
using IFoodyPagamento.Domain.Entities;
using IFoodyPagamento.Domain.Repositories;
using IFoodyPagamento.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace IFoodyPagamento.Repositories
{
    public class CartaoRepository : BaseRepository<CartaoCredito>, ICartaoRepository
    {
        const string OBTER_CARTAO_CLIENTE_QUERY = "select idCliente,idCartao,numero,validade,nomeTitular,cpf,idStripe from Cartao where idCartao = @idCartao";

        public async Task<CartaoCredito> ObterCartaoCliente(Guid idCartao)
        {
            DynamicParameters parms = new DynamicParameters();
            parms.Add("@idCartao", idCartao, DbType.Guid);

            return await ObterAsync<CartaoCredito>(OBTER_CARTAO_CLIENTE_QUERY, parms);
        }
    }
}
