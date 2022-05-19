using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Practice.Models
{
    public class User
    {
        public static BitmapImage DefaultIcon { get; set; }

        public User(string id, string fio, string role)
        {
            Id = id;
            Role = role;
            FIO = fio;
        }

        public User(string id, string fio, string role, BitmapImage icon)
            : this(id, fio, role)
        {
            Icon = icon;
        }



        public string Id { get; set; }
        public string Role { get; set; }
        public BitmapImage Icon { get; set; }
        public string FIO { get; set; }
    }
}
