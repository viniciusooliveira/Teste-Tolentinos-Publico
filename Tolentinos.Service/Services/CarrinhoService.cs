using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Tolentinos.Domain.Entities;
using Tolentinos.Domain.Interfaces;

namespace Tolentinos.Service.Services
{
    public class CarrinhoService : BaseService<Carrinho>
    {
        public CarrinhoService(IRepository<Carrinho> repository) : base(repository)
        {
        }

        public override Carrinho Post<V>(Carrinho obj)
        {
            obj.Data = DateTime.Now;
            return base.Post<V>(obj);
        }
    }
}
