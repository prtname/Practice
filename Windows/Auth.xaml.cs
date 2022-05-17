using Practice.DataAccess;
using Practice.Helpers;
using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practice.Windows
{
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();

            m_usersRepository = new ListUsersRepository();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            PhoneTxtBx.Clear();

            PassTxtBx.Clear();

            CodeTxtBx.Clear();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!PassTxtBx.IsEnabled)
                ValidatePhone();
            else if (!CodeTxtBx.IsEnabled)
                ValidatePassword();
            else
                ValidateCode();
        }

        private void ValidatePhone()
        {
            string phoneStr = PhoneTxtBx.Text;
            if (String.IsNullOrWhiteSpace(phoneStr) || !Phone.IsStringValidNumber(phoneStr))
            {
                MessageBox.Show("Неверный номер телефона");
                return;
            }

            m_phone = Phone.FromString(phoneStr);
            if (Authorization.ValidatePhone(m_usersRepository , Phone) == Authorization.Status.InvalidPhone)
            {
                MessageBox.Show("Пользователь с данным номером не существует", null);
                return;
            }

            PassTxtBx.IsEnabled = true;
            PassTxtBx.Focus();
        }

        private void ValidatePassword()
        {
            if (Authorization.ValidatePhonePassword(m_usersRepository, Phone, Password) == Authorization.Status.InvalidPassword)
            {
                MessageBox.Show("Неверный пароль");
                return;
            }

            Authorization.GenerateCode();

            CodeTxtBx.IsEnabled = true;
            RefreshCodeBtn.IsEnabled = true;
            CodeTxtBx.Focus();
        }

        private void ValidateCode()
        {
            var user = Authorization.Login(m_usersRepository, Phone, Password, Code);
            if (user == User.Empty)
            {
                MessageBox.Show("Неверный код", null);
                return;
            }

            MessageBox.Show(user.Role.Title);
        }

        private void PhoneTxtBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ValidatePhone();
            }
        }

        private void PassTxtBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ValidatePassword();
            }
        }

        private void CodeTxtBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ValidateCode();
            }
        }


        private void PhoneTxtBx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PassTxtBx.IsEnabled)
            {
                PassTxtBx.Clear();
                PassTxtBx.IsEnabled = false;
            }

            if (!String.IsNullOrWhiteSpace(PhoneTxtBx.Text) && Phone.IsStringValidNumber(PhoneTxtBx.Text))
            {
                LoginBtn.IsEnabled = true;
            }
            else
            {
                LoginBtn.IsEnabled = false;
            }
        }

        private void PassTxtBx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CodeTxtBx.IsEnabled)
            {
                CodeTxtBx.Clear();
                CodeTxtBx.IsEnabled = false;
                RefreshCodeBtn.IsEnabled = false;
            }
        }

        private void CodeTxtBx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(CodeTxtBx.Text)) LoginBtn.IsEnabled = true;
            else LoginBtn.IsEnabled = false;
        }

        private Phone Phone => m_phone;
        private string Password => PassTxtBx.Text;
        private string Code => CodeTxtBx.Text;


        private UsersRepository m_usersRepository;
        private Phone m_phone = Phone.Empty;

        private void RefreshCodeBtn_Click(object sender, RoutedEventArgs e)
        {
            Authorization.GenerateCode();
        }
    }
}
