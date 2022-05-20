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
        IEnumerable<User> GetAllUsers();
    }
}
