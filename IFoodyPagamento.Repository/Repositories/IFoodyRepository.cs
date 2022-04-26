using IFoodyPagamento.Domain;
using IFoodyPagamento.Domain.Dtos;
using IFoodyPagamento.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IFoodyPagamento.Infrastructure.Repositories
{
    public class IFoodyRepository : BaseServiceRepository, IIFoodyRepository
    {
        public IFoodyRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }

        public async Task ConfirmarPagamento(ConfirmacaoPagamentoDto confirmacaoPedido,string tokenAutenticacao)
        {
            var nomeClient = Constantes.IFoody.NOME_API_IFOODY;
            var endpoint = "http://localhost:26373/api/pedidos/pagamento/confirmar";
            var header = new Dictionary<string, string>
            {
                {"authorization",tokenAutenticacao }
            };

            await PostSemRetorno(nomeClient, endpoint, confirmacaoPedido, header);

        }
    }
}
