using IFoodyPagamento.Application.Models;
using IFoodyPagamento.Domain.Dtos;
using IFoodyPagamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFoodyPagamento.Application.Interfaces
{
    public interface IUsuarioApplication
    {
        Task<UsuarioStripeOutput> CadastrarCliente(UsuarioDto usuario);
        Task<CartaoStripeOutput> CadastrarCartao(CartaoCreditoInput cartao);
    }
}
