namespace InfoSystem.Infrastructure.Entities
{
    using System.Collections.Generic;

    public class Market : Identity
    {
        public string Name { get; set; }

        public List<MarketProduct> Products { get; set; }
    }
}