using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoSystem.App.DataBase.Entities
{
    public class MarketProduct : Identity
    {

        public int MarketId { get; set; }
        public Market Market { get; set; }


        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
