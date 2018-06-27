using MapperViewModels.ViewModels;
using SGQP.Domain.Entities;

namespace SGQP.Domain.Interfaces.Services
{
    public interface IServiceUser
    {
        void SaveUser(RegisterUserViewModel registerUser);
        User GetUser(string username);
    }
}
