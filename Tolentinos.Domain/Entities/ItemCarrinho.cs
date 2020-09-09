namespace Tolentinos.Domain.Entities
{
    public class ItemCarrinho : BaseEntity
    {
        public long IdCarrinho { get; set; }
        public long IdProduto { get; set; }
        public int Quantidade { get; set; }

        public Carrinho Carrinho { get; set; }
        public Produto Produto { get; set; }
    }
}