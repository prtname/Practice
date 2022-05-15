using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Models
{
    public class UserRole
    {
        public static UserRole Empty = new UserRole(0, string.Empty);

        public UserRole(int id, string title)
        {
            m_id = id;
            m_title = title;
        }

        public int Id => m_id;
        public string Title => m_title;


        private int m_id;
        private string m_title;
    }
}
