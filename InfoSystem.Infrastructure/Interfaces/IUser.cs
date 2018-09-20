using System.Collections.Immutable;
using InfoSystem.Infrastructure.Entities;

namespace InfoSystem.Infrastructure.Interfaces
{
    public interface IUser
    {
        ImmutableList<Market> GetMarkets();
    }
}