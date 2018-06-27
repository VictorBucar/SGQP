using SGQP.Domain.Entities;

namespace SGQP.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string username);
        void SaveUser(User user);
    }
}
