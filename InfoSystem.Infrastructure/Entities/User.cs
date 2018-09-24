using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using InfoSystem.Infrastructure.Interfaces;

namespace InfoSystem.Infrastructure.Entities
{
    public class User : Identity, IUser
    {
        public string Username { get; private set; }
        // public Uri ContactPage { get; private set; }
        public string FirstName { get; }
        public string LastName { get; }
        //public Uri ForumPage { get; set; } ???
        
        private List<Market> _markets;

        public User() => _markets = new List<Market>();
        public User(string nickname, string firstName = null, string lastName = null, string contactUrl = null)
        {
            Username = nickname;
            FirstName = firstName;
            LastName = lastName;
            //ContactPage = new Uri(contactUrl);
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