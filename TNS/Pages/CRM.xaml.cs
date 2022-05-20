using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для CRM.xaml
    /// </summary>
    public partial class CRM : Page
    {
        static CRM()
        {
            m_services = new Dictionary<string, string[]>();
            
            m_services.Add("Подключение", new string[]
            {
                "Подключение услуг с новой инфраструктурой",
                "Подключение услуг на существующей инфраструктуре"
            });

            m_services.Add("Управление договором/контактными данными", new string[]
            {
                "Изменение условий договора",
                "Включение в договор дополнительной услуги",
                "Изменение контактных данных"
            });

            m_services.Add("Управление тарифом/услугой", new string[]
            {
                "Изменение тарифа",
                "Изменение адреса предоставления услуг",
                "Отключение услуги",
                "Приостановка предоставления услуги"
            });

            m_services.Add("Диагностика и настройка оборудования/подключения", new string[]
            {
                "Нет доступа к услуге",
                "Разрыв соединения",
                "Низкая скорость соединения",
            });

            m_services.Add("Оплата услуг", new string[]
            {
                "Выписка по платежам",
                "Информация о платежах",
                "Получение квитанции на оплату услуги",
            });
        }

        public CRM()
        {
            InitializeComponent();

            CreationDate.Text = DateTime.Today.ToShortDateString();
            CloseDate.Text = DateTime.Today.ToShortDateString();
        }


        private static Dictionary<string, string[]> m_services;

        private void ServiceType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeOfService.ItemsSource = m_services[SelectedServiceType];
            TypeOfService.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var command = new SqlCommand("INSERT INTO Zayavki VALUES (@number, " +
                "@creation, @ls, @service, @serviceType, @typeOfService, @status, " +
                "@hardwareType, @description, @close, @issueType)", MainWindow.connection);
            command.Parameters.AddRange(new List<SqlParameter>
            {
                new SqlParameter("@number", ApplicationNumber.Text),
                new SqlParameter("@creation", DateTime.Today),
                new SqlParameter("@ls", Double.Parse(AccountNumber.Text)),
                new SqlParameter("@service", Service.Text),
                new SqlParameter("@serviceType", SelectedServiceType),
                new SqlParameter("@typeOfService", SelectedTypeOfService),
                new SqlParameter("@status", Status.Text),
                new SqlParameter("@hardwareType", HardwareType.Text),
                new SqlParameter("@description", Description.Text),
                new SqlParameter("@close", DateTime.Today),
                new SqlParameter("@issueType", IssueType.Text)
            }.ToArray());

            try
            {
                int i = command.ExecuteNonQuery();
                if (i > 0) MessageBox.Show("Заявка успешно добавлена", "Да", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string SelectedServiceType => ((ComboBoxItem)ServiceType.SelectedItem).Content.ToString();
        private string SelectedTypeOfService => TypeOfService.SelectedItem.ToString();

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            double i = random.Next() % 100;
            if (i > 75)
                Status.Text = "Требует выезда";
            else
                Status.Text = "Закрытая";
        }
    }
}
