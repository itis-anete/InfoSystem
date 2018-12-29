using System.Collections.Generic;
using InfoSystem.Infrastructure.Entities;

namespace InfoSystem.App.DataBase.ReposInterfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool AuthoriseUser(User user);
    }
}