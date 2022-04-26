using IFoodyPagamento.Application.Interfaces;
using IFoodyPagamento.Application.Models;
using IFoodyPagamento.Domain.Dtos;
using IFoodyPagamento.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IFoodyPagamento.Api.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApplication _usuarioService;
        public UsuarioController(IUsuarioApplication cobrancaService)
        {
            _usuarioService = cobrancaService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuarioStripe([FromBody]UsuarioDto usuarioInput)
        {
            var usuario = await _usuarioService.CadastrarCliente(usuarioInput);
            return Created("", usuario);
        }

        [HttpPost]
        [Route("cartao")]
        public async Task<IActionResult> CadastrarCartaoStripe([FromBody]CartaoCreditoInput cartaoInput)
        {
            var cartao = await _usuarioService.CadastrarCartao(cartaoInput);
            return Ok(cartao);
        }

    }
}
