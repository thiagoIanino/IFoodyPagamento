using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IFoodyPagamento.Infrastructure.Repositories
{
    public class BaseServiceRepository
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        public BaseServiceRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        protected async Task PostSemRetorno<TBody>(string nomeUrlBase, string requestUrl, TBody body, Dictionary<string, string> headers, int? timeOut = null)
        {
            var client = _httpClientFactory.CreateClient(nomeUrlBase);

            if (timeOut.HasValue)
            {
                client.Timeout = TimeSpan.FromSeconds(timeOut.Value);
            }
            if (headers != null && headers.Any())
            {
                try
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }catch(Exception ex)
                {
                    var teste = ex;
                }
            }
            using var response = await client.PostAsJsonAsync(requestUrl, body);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
