using System.Collections.Generic;

namespace InfoSystem.Core.Entities
{
    public class Market : Identity
    {
        public string Name { get; private set; }
        public List<MarketProduct> Products { get; set; }

        public Market() { }
        public Market(string receivedName)
        {
            Name = receivedName;
        }
    }
}