using System;
using System.Collections.Generic;
using System.Text;

namespace Tolentinos.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public long IdMarca { get; set; }
        public long IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string DescricaoNoHtml { get; set; }
        public decimal Valor { get; set; }
        public string Tamanho { get; set; }
        public string Cor { get; set; }
        public long QuantidadeDisponivel { get; set; }

        public Categoria Categoria { get; set; }
        public Marca Marca { get; set; }

        public IEnumerable<ImagemProduto> Imagens { get; set; }
        public IEnumerable<ItemCarrinho> ItensCarrinho { get; set; }
    }
}
