using BlogCore.Core.Entities;
using System;
using System.Linq;

namespace BlogCore.Db
{
    public class UserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public UserRepository()
        {
            _context = new ApplicationContext();
        }

        public void AddUser(string login, string password)
        {
            if (!_context.Users.Any(user => user.Login == login))
                _context.Add(new User(login, password));
            _context.SaveChanges();
        }

        public bool CheckUser(string login)
        {
            if (_context.Users.Any(u => u.Login == login))
                return true;
            return false;
        }

        public bool CheckPassword(string login, string password)
        {
            return _context.Users.First(u => u.Login == login).Password.Equals(password);
        }

        public User GetUserById(Guid id)
        {
            return _context.Users.First(u => u.Id == id);
        }

        public User GetUserByLogin(string login)
        {
            return _context.Users.First(u => u.Login == login);
        }
    }
}
