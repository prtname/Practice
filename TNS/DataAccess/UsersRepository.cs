using Practice.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DataAccess
{
    public interface UsersRepository
    {
        User GetUser(Phone phone, string password);
        bool HasUser(Phone phone, string password);
        bool HasUserWithPhone(Phone phone);
        IEnumerable<User> GetAllUsers();
    }
}
