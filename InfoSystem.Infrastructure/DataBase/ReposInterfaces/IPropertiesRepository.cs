using System.Collections.Generic;
using InfoSystem.Core.Entities;

namespace InfoSystem.Infrastructure.DataBase.ReposInterfaces
{
    public interface IPropertiesRepository : IBaseRepository<Properties>
    {
        IEnumerable<Properties> GetByEntityId(int entityId);
    }
}