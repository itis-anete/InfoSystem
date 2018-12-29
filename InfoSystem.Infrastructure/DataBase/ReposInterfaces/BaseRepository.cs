using System.Collections;
using System.Collections.Generic;

namespace InfoSystem.App.DataBase.ReposInterfaces
{
    public interface IBaseRepository<T>
    {
        void Add(T receivedObj);
        void Delete(int id);
        IEnumerable<T> Get();
        T Get(int id);
    }
}