namespace InfoSystem.Infrastructure.Entities
{
    using System.Collections.Generic;

    public class Product : Identity
    {
        public Product() { }
        public Product(string receivedName)
        {
            Name = receivedName;
        }
        
        public string Name { get; }
        public decimal Cost { get; }
        public List<MarketProduct> InMarkets { get; }
    }
}