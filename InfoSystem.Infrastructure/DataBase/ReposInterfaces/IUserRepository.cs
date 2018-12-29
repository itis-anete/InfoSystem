using InfoSystem.Core.Entities;

namespace InfoSystem.Infrastructure.DataBase.ReposInterfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool AuthoriseUser(User user);
    }
}