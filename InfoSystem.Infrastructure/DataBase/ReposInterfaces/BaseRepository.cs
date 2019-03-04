using System.Collections.Generic;

namespace InfoSystem.Infrastructure.DataBase.ReposInterfaces
{
    public interface IBaseRepository<T>
    {
        void Add(T receivedObj);
        void Delete(int id);
        IEnumerable<T> Get();
        T GetById(int id);
    }
}