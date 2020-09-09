using System;
using System.Collections.Generic;
using System.Text;

namespace Tolentinos.Domain.Entities
{
    public class Carrinho : BaseEntity
    {
        public long IdUsuario { get; set; }
        public DateTime Data { get; set; }

        public IEnumerable<ItemCarrinho> Itens { get; set; }
    }
}
