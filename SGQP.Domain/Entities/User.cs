using SGQP.Domain.ValueObjects;
using System;

namespace SGQP.Domain.Entities
{
    public class User
    {
        //public User(string username, string firstname, string lastname, string password)
        //{
        //    Password = new Password();

        //    Username = username;
        //    FirstName = firstname;
        //    LastName = lastname;
        //    Password.Content = password;
        //}

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + LastName;
        public string Password { get; set; }
        public bool IsActive => true;
    }
}
