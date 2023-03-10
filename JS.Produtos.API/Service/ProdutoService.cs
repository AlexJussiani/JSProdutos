using FluentValidation.Results;
using JS.Core.Messages;
using JS.Produtos.Domain.Models;
using JS.Produtos.Infra.Repository;
using JS.WebAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JS.Produtos.API.Service
{
    public class ProdutoService : CommandHandler
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<PagedResult<Produto>> ObterPageProdutos(int pageSize, int pageIndex, string query = null)
        {
            var clientes = await _produtoRepository.ObterPageTodos(pageSize, pageIndex, query);

            return new PagedResult<Produto>()
            {
                List = clientes,
                TotalResults = await _produtoRepository.TotalProdutos(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query
            };
        }

        public async Task<IEnumerable<Produto>> ObterProdutos()
        {
            return await _produtoRepository.ObterTodos();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosEntrada()
        {
            return await _produtoRepository.ObterProdutosEntrada();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosSaida()
        {
            return await _produtoRepository.ObterProdutosSaida();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            var produto = await _produtoRepository.ObterPorId(id);
            return produto;
        }
    }
}
