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
    /// Логика взаимодействия для Code.xaml
    /// </summary>
    public partial class Code : Window
    {
        public Code()
        {
            InitializeComponent();
            GenerateCode();
        }

        public string CodeStr
        {
            get
            {
                return m_code;
            }
            private set
            {
                m_code = value;
                CodeTxtBlc.Text = m_code;
            }
        }

        private void GenerateCode()
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+='\"{}[],./\\?;:|";
            var code = new StringBuilder();
            var random = new Random();

            for (int i = 0; i < 8; i++)
            {
                code.Append(chars[random.Next(chars.Length)]);
            }

            CodeStr = code.ToString();
        }


        private string m_code;
    }
}
