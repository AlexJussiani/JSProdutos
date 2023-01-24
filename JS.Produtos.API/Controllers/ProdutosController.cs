using JS.Core.Mediator;
using JS.Produtos.API.Service;
using JS.Produtos.API.Application.Commands;
using JS.Produtos.Domain.Models;
using JS.WebAPI.Core.Controllers;
using JS.WebAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using JS.Core.Data.EventSourcing;
using Microsoft.AspNetCore.Authorization;

namespace JS.Produtos.API.Controllers
{
    [Authorize]
    [Route("api/produtos")]
    public class ProdutosController : MainController
    {
        private readonly IMediatorHandler _mediator;
        ProdutoService _produtoService;
        public ProdutosController(ProdutoService produtoService,
            IMediatorHandler mediator)
        {
            _produtoService = produtoService;
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            return CustomResponse(await _produtoService.ObterProdutos());
        }

        [HttpGet("entrada")]
        public async Task<IActionResult> ObterProdutosEntrada()
        {
            return CustomResponse(await _produtoService.ObterProdutosEntrada());
        }

        [HttpGet("saida")]
        public async Task<IActionResult> ObterProdutosSaida()
        {
            return CustomResponse(await _produtoService.ObterProdutosSaida());
        }

        [HttpGet("Paginado")]
        public async Task<PagedResult<Produto>> IndexPaginado([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] string q = null)
        {
            return await _produtoService.ObterPageProdutos(ps, page, q);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _produtoService.ObterPorId(id));
        }

        [HttpPost()]
        public async Task<ActionResult> Registrar(RegistrarProdutoCommand produto)
        {
            return CustomResponse(await _mediator.EnviarComando(produto));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Atualizar(Guid id, AtualizarProdutoCommand produto)
        {
            if(id != produto.Id)
            {
                AdicionarErroProcessamento("O Id informado não é o mesmo informado na Query");
                return CustomResponse();
            }
            return CustomResponse(await _mediator.EnviarComando(produto));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Remover(Guid id, DeletarProdutoCommand deletarProduto)
        {
            return CustomResponse(await _mediator.EnviarComando(deletarProduto));
        }
    }
}
