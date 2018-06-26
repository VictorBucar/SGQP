using SGQP.Domain.Entities;

namespace SGQP.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string username);
        void SaveUser(string username, string firstname, string lastname, string password);
    }
}
