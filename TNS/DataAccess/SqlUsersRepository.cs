using Practice.DataAccess;
using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.DataAccess
{
    public class SqlUsersRepository : UsersRepository
    {
        public IEnumerable<User> GetAllUsers()
        {
            var command = MainWindow.connection.CreateCommand();
            command.CommandText = "SELECT * FROM Sotrudnik";

            List<User> users = new List<User>();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int i = reader.GetOrdinal("ФИО");
                string fio = reader.GetString(i);

                i = reader.GetOrdinal("ID");
                string id = reader.GetString(i);

                i = reader.GetOrdinal("Должность");
                string role = reader.GetString(i);

                users.Add(new User(id, fio, role));
            }

            return users;
        }
    }
}
