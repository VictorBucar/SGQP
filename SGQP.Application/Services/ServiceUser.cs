using MapperViewModels.ViewModels;
using SGQP.Domain.Entities;
using SGQP.Domain.Interfaces.Repositories;
using SGQP.Domain.Interfaces.Services;
using SGQP.Domain.ValueObjects;

namespace SGQP.Application.Services
{
    public class ServiceUser : IServiceUser
    {
        private readonly IUserRepository _userRepository;

        public ServiceUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void SaveUser(RegisterUserViewModel registerUser)
        {
            Password psw = new Password();

            var salt = psw.CreateSalt();
            var hash = psw.CreateHash(registerUser.Password, salt);

            User user = new User
            {
                Username = registerUser.Username,
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName,
                Salt = salt,
                Password = hash
            };

            _userRepository.SaveUser(user);
        }

        public User GetUser(string username) => _userRepository.GetUser(username);
    }
}
