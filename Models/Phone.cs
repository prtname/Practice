using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Models
{
    public class Phone
    {
        public Phone(int id, char countryCode, char[] number)
            : this(countryCode, number)
        {
            m_id = id;
        }

        public Phone(char countryCode, char[] number)
        {
            m_countryCode = countryCode;
            m_number = number;
        }




        public int Id => m_id;
        public char CountryCode => m_countryCode;
        public char[] Number => m_number;



        private int m_id;
        private char m_countryCode;
        private char[] m_number;
    }
}
