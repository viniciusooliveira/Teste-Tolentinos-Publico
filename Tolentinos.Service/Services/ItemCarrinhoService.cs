using Amazon.S3.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tolentinos.Domain.Entities;
using Tolentinos.Domain.Interfaces;

namespace Tolentinos.Service.Services
{
    public class ItemCarrinhoService : BaseService<ItemCarrinho>
    {
        private readonly IService<Produto> _produtoService;
        public ItemCarrinhoService(IRepository<ItemCarrinho> repository, IService<Produto> produtoService) : base(repository)
        {
            _produtoService = produtoService;
        }

        public override ItemCarrinho Post<V>(ItemCarrinho obj)
        {

            var produto = _produtoService.Get(obj.IdProduto);

            if(produto != null)
            {
                if(produto.QuantidadeDisponivel < obj.Quantidade)
                {
                    throw new ValidationException("Quantidade indisponível!");
                }

                return base.Post<V>(obj);
            }
            throw new ValidationException("Produto não encontrado!");
        }

        public override ItemCarrinho Put<V>(ItemCarrinho obj)
        {
            var produto = _produtoService.Get(obj.IdProduto);

            if (produto != null)
            {
                if (produto.QuantidadeDisponivel < obj.Quantidade)
                {
                    throw new ValidationException("Quantidade indisponível!");
                }

                return base.Put<V>(obj);
            }
            throw new ValidationException("Produto não encontrado!");
        }
    }
}
