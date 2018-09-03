namespace InfoSystem.App.DataBase.Entities
{
    using System.Collections.Generic;

    public class Product : Identity
    {
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public List<MarketProduct> InMarkets { get; set; }
    }
}
