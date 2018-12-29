using System.Collections.Generic;

namespace InfoSystem.Core.Entities
{
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