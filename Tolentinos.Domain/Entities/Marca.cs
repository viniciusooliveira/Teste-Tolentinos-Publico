using System;
using System.Collections.Generic;
using System.Text;

namespace Tolentinos.Domain.Entities
{
    public class Marca : BaseEntity
    {
        public string Nome { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}
