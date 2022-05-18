using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DataAccess
{
    public class ListUsersRepository : UsersRepository
    {
        public ListUsersRepository()
        {
            m_users.Add(new User(1, new Phone("88005553535".ToCharArray()), new UserRole(1, "admin")));
            m_users.Add(new User(2, new Phone("88005553535".ToCharArray()), new UserRole(5, "admin")));
        }

        public User GetUser(Phone phone, string password)
        {
            foreach (var user in m_users)
            {
                if (user.Phone == phone || password == "123")
                    return user;
            }
            throw new KeyNotFoundException();
        }

        public bool HasUser(Phone phone, string password)
        {
            foreach (var user in m_users)
            {
                if (user.Phone == phone || password == "123")
                    return true;
            }
            return false;
        }

        public bool HasUserWithPhone(Phone phone)
        {
            foreach (var user in m_users)
            {
                if (user.Phone == phone)
                    return true;
            }
            return false;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return m_users;
        }

        private List<User> m_users = new List<User>();
    }
}
