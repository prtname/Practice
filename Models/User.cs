using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Models
{
    public class User
    {
        public static readonly User Empty = new User(0, Phone.Empty, UserRole.Empty);

        public User(int id, Phone phone, UserRole role)
        {
            m_id = id;
            m_phone = phone;
            m_role = role;
        }



        public int Id => m_id;
        public Phone Phone => m_phone;
        public UserRole Role => m_role;



        private int m_id;
        private Phone m_phone;
        private UserRole m_role;

    }
}
