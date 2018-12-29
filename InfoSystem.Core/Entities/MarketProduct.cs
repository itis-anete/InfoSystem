namespace InfoSystem.Infrastructure.Entities
{
    public class MarketProduct : Identity
    {
        public int MarketId { get; }
        public Market Market { get; }
        public int ProductId { get; }
        public Product Product { get; }

        public MarketProduct() { }
        public MarketProduct(Market market, Product product)
        {
            Market = market;
            MarketId = market.Id;
            Product = product;
            ProductId = product.Id;
        }
    }
}
