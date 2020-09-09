using System;
using System.Collections.Generic;
using System.Text;

namespace Tolentinos.Domain.Entities
{
    public class Categoria : BaseEntity
    {
        public string Nome { get; set; }

        public int Ordem { get; set; }

        public long? IdPai { get; set; }

        public IEnumerable<Categoria> Filhos { get; set; }

        public Categoria Pai { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}
