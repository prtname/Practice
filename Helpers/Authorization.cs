using Practice.DataAccess;
using Practice.Models;
using Practice.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace Practice.Helpers
{
    public static class Authorization
    {

        static Authorization()
        {
            m_timer = new Timer();
            m_timer.Elapsed += Timer_Elapsed;
            m_timer.AutoReset = false;
            m_timer.Interval = 10000;
        }
        public enum Status { Success, InvalidPhone, InvalidPassword, InvalidCode }

        public static Status ValidatePhone(UsersRepository users, Phone phone)
        {
            return users.HasUserWithPhone(phone) ? Status.Success : Status.InvalidPhone;
        }

        public static Status ValidatePhonePassword(UsersRepository users, Phone phone, string password)
        {
            return users.HasUser(phone, password) ? Status.Success : Status.InvalidPassword;
        }

        public static void GenerateCode()
        {
            m_timer.Stop();

            var code = new Code();
            m_code = code.CodeStr;
            code.ShowDialog();

            m_timer.Start();
        }

        private static void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            m_isCodeExpired = true;
        }

        public static User Login(UsersRepository users, Phone phone, string password, string code)
        {
            if (m_isCodeExpired) return User.Empty;

            if (ValidatePhonePassword(users, phone, password) == Status.InvalidPassword) return User.Empty;

            if (code != m_code) return User.Empty;

            return users.GetUser(phone, password);
        }



        private static string m_code = String.Empty;
        private static bool m_isCodeExpired = false;
        private static Timer m_timer;
    }
}
