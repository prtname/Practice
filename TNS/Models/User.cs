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
        public static readonly User Empty = new User(0, String.Empty, String.Empty, String.Empty, Phone.Empty, UserRole.Empty);
        public static BitmapImage DefaultIcon { get; set; }

        public User(int id, string firstName, string middleName, string lastName, Phone phone, UserRole role)
        {
            m_id = id;
            m_phone = phone;
            m_role = role;
            m_icon = DefaultIcon;
            m_firstName = firstName;
            m_middleName = middleName;
            m_lastName = lastName;
        }

        public User(int id, string firstName, string middleName, string lastName, Phone phone, UserRole role, BitmapImage icon)
            : this(id, firstName, middleName, lastName, phone, role)
        {
            m_icon = icon;
        }



        public int Id => m_id;
        public Phone Phone => m_phone;
        public UserRole Role => m_role;
        public BitmapImage Icon => m_icon;
        public string FirstName => m_firstName;
        public string MiddleName => m_middleName;
        public string LastName => m_lastName;



        private int m_id;
        private Phone m_phone;
        private UserRole m_role;
        private BitmapImage m_icon;
        private string m_firstName;
        private string m_middleName;
        private string m_lastName;
    }
}
