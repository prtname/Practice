using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Models
{
    public class Phone
    {
        public static Phone Empty = new Phone((char)0, Array.Empty<char>());

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


        public static bool IsStringValidNumber(string number)
        {
            if (number.Length < 11) return false;

            for (int i = 0; i < number.Length; i++)
            {
                if (i == 0 && number[i] == '+') continue;
                if (number[i] < '0' || number[i] > '9') return false;
            }
            return true;
        }

        public static Phone FromString(string number)
        {
            if (!IsStringValidNumber(number)) throw new FormatException();

            char countryCode;
            if (number[0] == '+')
            {
                if (number[1] == '7') countryCode = '8';
                else throw new FormatException();
            }
            else
            {
                if (number[0] != '8') throw new FormatException();
                countryCode = number[0];
            }

            return new Phone(countryCode, number.Substring(1).ToCharArray());
        }



        public int Id => m_id;
        public char CountryCode => m_countryCode;
        public char[] Number => m_number;



        private int m_id;
        private char m_countryCode;
        private char[] m_number;
    }
}
