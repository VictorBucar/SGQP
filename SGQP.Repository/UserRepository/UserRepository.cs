using SGQP.Data.Contexts;
using SGQP.Domain.Entities;
using SGQP.Domain.Interfaces.Repositories;
using SGQP.Domain.ValueObjects;
using System.Linq;

namespace SGQP.Repository.UserReposiory
{
    public class UserRepository : IUserRepository
    {
        private readonly DefaultContext _ctx;

        public UserRepository(DefaultContext ctx)
        {
            _ctx = ctx;
        }

        public User GetUser(string username) => _ctx.Set<User>().Where(x => x.Username == username).FirstOrDefault();

        public void SaveUser(string username, string firstname, string lastname, string password)
        {
            Password psw = new Password();

            var salt = psw.CreateSalt();
            var hash = psw.CreateHash(password, salt);

            var user = new User()
            {
                Username = username,
                FirstName = firstname,
                LastName = lastname,
                Password = hash
            };

            _ctx.Set<User>().Add(user);
            _ctx.SaveChanges();
        }
    }
}
