using IFoodyPagamento.Domain.Dtos;
using IFoodyPagamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFoodyPagamento.Domain.Repositories
{
    public interface IStripeRepository
    {
        Task<dynamic> PagarAsync(CartaoCredito cartao, string idRestaurante, Pedido pedido);
        Task<string> CadastrarUsuario(UsuarioDto usuario);
        Task<string> CadastrarCartaoCliente(CartaoCreditoDto cartao);
        Task ConfirmarPagamento(string idPagamento);
    }
}
