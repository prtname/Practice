using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace TNS
{
    /// <summary>
    /// Логика взаимодействия для CustomerDetails.xaml
    /// </summary>
    public partial class CustomerDetails : Window
    {
        public CustomerDetails(string abonentNumber)
        {
            InitializeComponent();

            var command = new SqlCommand("SELECT * FROM Abonenti WHERE Номер_абонента=@number", MainWindow.connection);
            command.Parameters.Add(new SqlParameter("@number", abonentNumber));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable("Abonenti");
            adapter.Fill(dt);

            DtGrid.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
