using IFoodyPagamento.Domain;
using IFoodyPagamento.Domain.Dtos;
using IFoodyPagamento.Domain.Entities;
using IFoodyPagamento.Domain.Repositories;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFoodyPagamento.Infrastructure.Repositories
{
    public class StripeRepository : IStripeRepository
    {
        public async Task<string> CadastrarUsuario(UsuarioDto usuario)
        {

            StripeConfiguration.ApiKey = "sk_test_51KHJ9UEvgleluHzw37WEpzMaI4iXo4f8pJtqt4anWf0NTBOnzrogvnwX6wRNbSCF4FUgd4EjtEnpf5pwue79tC2O00mYEBT6vp";

            var options = new CustomerCreateOptions
            {
                Name = usuario.Nome,
                Email = usuario.Email,
                Description = usuario.Categoria.ToString(),
                
            };
            var service = new CustomerService();
            var customer = await service.CreateAsync(options);

            return customer.Id;
        }

        public async Task<string> CadastrarCartaoCliente(CartaoCreditoDto cartao)
        {

            StripeConfiguration.ApiKey = Parametros.STRIPE_KEY;

            //Aqui seria colocado os dados reais do cartão
            //Porém por ser uma plicação teste para estudo, apenas passo o codigo para criar um cartão fake
            var options = new CardCreateOptions
            {
                Source = "tok_visa"
            };
            var service = new CardService();
            var cartaoStripe = await service.CreateAsync(cartao.IdStripeCliente, options);

            return cartaoStripe.Id;
        }


        public async Task<dynamic> PagarAsync(CartaoCredito cartao ,string idCliente, Pedido pedido)
        {
            StripeConfiguration.ApiKey = Parametros.STRIPE_KEY;
            var options = new PaymentIntentCreateOptions
            {
                Customer = idCliente,
                Currency = "brl",
                Amount = (int)pedido.ValorTotal * 100,
                PaymentMethodTypes = new List<string> { "card" },
                SetupFutureUsage = "on_session",
                PaymentMethod = cartao.IdStripe
            };
            var service = new PaymentIntentService();
            var pagamento = await service.CreateAsync(options);

            return pagamento.Id;
        }

        public async Task ConfirmarPagamento(string idPagamento)
        {
            StripeConfiguration.ApiKey = Parametros.STRIPE_KEY;

            var options = new PaymentIntentConfirmOptions
            {
                PaymentMethod = "pm_card_visa",
            };
            var service = new PaymentIntentService();
            await service.ConfirmAsync(
              idPagamento,
              options);
        }
    }
}
