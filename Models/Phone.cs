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

        public Phone(int id, char[] number)
            : this(number)
        {
            m_id = id;
        }

        public Phone(char[] number)
        {
            m_number = number;
        }


        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Phone phone = (Phone)obj;
            if (this.m_number.Length != phone.m_number.Length) return false;

            for (int i = 0; i < this.m_number.Length; i++)
            {
                if (this.m_number[i] != phone.m_number[i]) return false;
            }

            return true;
        }

        public static bool operator !=(Phone phone1, Phone phone2)
        {
            return !phone1.Equals(phone2);
        }

        public static bool operator ==(Phone phone1, Phone phone2)
        {
            return phone1.Equals(phone2);
        }

        public static bool IsStringValidNumber(string number)
        {
            if (number.Length < 11) return false;
            return true;
        }

        public static Phone FromString(string number)
        {
            if (!IsStringValidNumber(number)) throw new FormatException();

            return new Phone(number.ToCharArray());
        }



        public int Id => m_id;
        public char[] Number => m_number;



        private int m_id;
        private char[] m_number;

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
