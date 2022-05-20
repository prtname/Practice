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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TNS.Pages
{
    /// <summary>
    /// Логика взаимодействия для Subscribers.xaml
    /// </summary>
    public partial class Subscribers : Page
    {
        private class UserEvent
        {
            public string Text { get; set; }
        }
        public Subscribers()
        {
            string role = MainWindow.CurrentUserRole;
            var command = new SqlCommand("SELECT *, concat_ws(', ', Услуги, Услуги1, Услуги2) AS Все_услуги FROM Abonenti", MainWindow.connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable("Abonenti");
            adapter.Fill(dt);

            m_dataView = new DataView(dt);

            command = new SqlCommand("SELECT События FROM InformDlyaSotrudnikov WHERE Должность=@role", MainWindow.connection);
            command.Parameters.Add(new SqlParameter("@role", role));
            var events = new List<UserEvent>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    foreach (string ev in reader.GetString(0).Split(','))
                    {
                        events.Add(new UserEvent()
                        {
                            Text = ev.Replace(';', '\n')
                        });
                    }
                }
            }

            InitializeComponent();
            EventsControl.ItemsSource = events;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //var command = new SqlCommand("SELECT Номер_абонента AS [Номер абонента], Номер_договора AS [Номер договора], Лицевой_счет AS [Лицевой счет], concat_ws(', ', Услуги, Услуги1, Услуги2) AS Услуги FROM Abonenti", MainWindow.connection);
            DtGrid.ItemsSource = m_dataView;
        }

        private void ActiveClientsChkBx_Checked(object sender, RoutedEventArgs e)
        {
            if (InactiveClientsChkBx == null) return;

            if (InactiveClientsChkBx.IsChecked == true)
                m_dataView.RowFilter = "";
            else
                m_dataView.RowFilter = "Причина_расторжения_договора is null";
        }

        private void InactiveClientsChkBx_Checked(object sender, RoutedEventArgs e)
        {
            if (ActiveClientsChkBx == null) return;

            if (ActiveClientsChkBx.IsChecked == true)
                m_dataView.RowFilter = "";
            else
                m_dataView.RowFilter = "Причина_расторжения_договора is not null";
        }


        private DataView m_dataView;

        private void ActiveClientsChkBx_Unchecked(object sender, RoutedEventArgs e)
        {
            if (InactiveClientsChkBx.IsChecked == true)
                m_dataView.RowFilter = "Причина_расторжения_договора is not null";
            else
                m_dataView.RowFilter = "1=0";
        }

        private void InactiveClientsChkBx_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ActiveClientsChkBx.IsChecked == true)
                m_dataView.RowFilter = "Причина_расторжения_договора is null";
            else
                m_dataView.RowFilter = "1=0";
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = DtGrid.SelectedItem as DataRowView;
            var window = new CustomerDetails(row.Row.ItemArray[0].ToString());
            window.Show();
        }
    }
}
