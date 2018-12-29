using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using InfoSystem.Core.Interfaces;

namespace InfoSystem.Core.Entities
{
    public class User : Identity, IUser
    {
        public string Username { get; private set; }
        public string FirstName { get; }
        public string LastName { get; }
        
        private List<Market> _markets;

        public User() => _markets = new List<Market>();
        public User(string nickname, string firstName = null, string lastName = null, string contactUrl = null)
        {
            Username = nickname;
            FirstName = firstName;
            LastName = lastName;
        }


        public void CreateMarket(string receivedName, params Product[] receivedProducts)
        {
            var newMarket = new Market(receivedName);
            var productsToNewMarket = receivedProducts
                .Select(product => new MarketProduct(newMarket,product))
                .ToList();
            newMarket.Products = productsToNewMarket;
            _markets.Add(newMarket);
        }

        public ImmutableList<Market> GetMarkets()
        {
            return _markets.ToImmutableList();
        }
    }
}