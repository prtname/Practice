using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

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
            }
        }

        private void CodeTxtBx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(CodeTxtBx.Text)) LoginBtn.IsEnabled = true;
            else LoginBtn.IsEnabled = false;
        }

        private void PhoneTxtBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PassTxtBx.IsEnabled = true;
                PassTxtBx.Focus();
            }
        }

        private void PassTxtBx_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CodeTxtBx_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
