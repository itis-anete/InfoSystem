using System.Collections.Immutable;
using InfoSystem.Core.Entities;

namespace InfoSystem.Core.Interfaces
{
    public interface IUser
    {
        ImmutableList<Market> GetMarkets();
    }
}