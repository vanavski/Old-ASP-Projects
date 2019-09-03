using System;

namespace BlogCore.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User(string login, string password)
        {
            Id = Guid.NewGuid();
            Login = login;
            Password = password;
        }
    }
}
