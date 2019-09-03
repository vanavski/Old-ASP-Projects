using NewVision.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewVision.Db.Interfaces
{
    public interface IUserRepository
    {
        void Add(string login, string password, Roles role);
        void Delete(User user);
        User Get(string login);
        User Get(Guid id);
        bool Contains(string login);
        void ChangeRole(string login, Roles newRole);
    }
}
