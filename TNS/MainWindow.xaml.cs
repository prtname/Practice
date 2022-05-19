using Practice.DataAccess;
using Practice.Models;
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
using TNS.DataAccess;

namespace TNS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static SqlConnection connection = new SqlConnection(@"Data Source=(local); Initial Catalog=Uchet.Ses2;Integrated Security=True");

        static MainWindow()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невозможно подключится к базе данных.\nНажмите ОК для завершения.", null, MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }

            m_menuItems = new Dictionary<string, MenuItem[]>();

            m_menuItems.Add(
                "Руководитель отдела по работе с клиентами",
                new MenuItem[] {
                    new MenuItem("Абоненты", "Абоненты ТНС", new Uri("Pages/Subscribers.xaml", UriKind.Relative)),
                    new MenuItem("CRM", "CRM", new Uri("Pages/CRM.xaml", UriKind.Relative)),
                    new MenuItem("Биллинг", "Биллинг", new Uri("Pages/Billing.xaml", UriKind.Relative)),
                }
            );

            m_menuItems.Add(
                "Менеджер по работе с клиентами",
                new MenuItem[] {
                    new MenuItem("Абоненты", "Абоненты ТНС", new Uri("Pages/Subscribers.xaml", UriKind.Relative)),
                    new MenuItem("CRM", "CRM", new Uri("Pages/CRM.xaml", UriKind.Relative)),
                }
            );

            m_menuItems.Add(
                "Руководитель отдела технической поддержки",
                new MenuItem[] {
                    new MenuItem("Абоненты", "Абоненты ТНС", new Uri("Pages/Subscribers.xaml", UriKind.Relative)),
                    new MenuItem("Поддержка пользователей", "Поддержка пользователей", new Uri("Pages/Support.xaml", UriKind.Relative)),
                    new MenuItem("CRM", "CRM", new Uri("Pages/CRM.xaml", UriKind.Relative)),
                    new MenuItem("Управление оборудованием", "Управление оборудованием", new Uri("Pages/HardwareControl.xaml", UriKind.Relative))
                }
            );

            m_menuItems.Add(
                "Специалист ТП (выездной инженер)",
                new MenuItem[] {
                    new MenuItem("Абоненты", "Абоненты ТНС", new Uri("Pages/Subscribers.xaml", UriKind.Relative)),
                    new MenuItem("Поддержка пользователей", "Поддержка пользователей", new Uri("Pages/Support.xaml", UriKind.Relative)),
                    new MenuItem("CRM", "CRM", new Uri("Pages/CRM.xaml", UriKind.Relative)),
                    new MenuItem("Управление оборудованием", "Управление оборудованием", new Uri("Pages/HardwareControl.xaml", UriKind.Relative))
                }
            );

            m_menuItems.Add(
                "Бухгалтер",
                new MenuItem[] {
                    new MenuItem("Абоненты", "Абоненты ТНС", new Uri("Pages/Subscribers.xaml", UriKind.Relative)),
                    new MenuItem("Биллинг", "Биллинг", new Uri("Pages/Billing.xaml", UriKind.Relative)),
                    new MenuItem("Активы", "Активы", new Uri("Pages/Assets.xaml", UriKind.Relative))
                }
            );

            m_menuItems.Add(
                "Директор по развитию",
                new MenuItem[] {
                    new MenuItem("Абоненты", "Абоненты ТНС", new Uri("Pages/Subscribers.xaml", UriKind.Relative)),
                    new MenuItem("Поддержка пользователей", "Поддержка пользователей", new Uri("Pages/Support.xaml", UriKind.Relative)),
                    new MenuItem("CRM", "CRM", new Uri("Pages/CRM.xaml", UriKind.Relative)),
                    new MenuItem("Управление оборудованием", "Управление оборудованием", new Uri("Pages/HardwareControl.xaml", UriKind.Relative)),
                    new MenuItem("Биллинг", "Биллинг", new Uri("Pages/Billing.xaml", UriKind.Relative)),
                    new MenuItem("Активы", "Активы", new Uri("Pages/Assets.xaml", UriKind.Relative))
                }
            );

            m_menuItems.Add(
                "Технический департамент",
                new MenuItem[] {
                    new MenuItem("Абоненты", "Абоненты ТНС", new Uri("Pages/Subscribers.xaml", UriKind.Relative)),
                    new MenuItem("Активы", "Активы", new Uri("Pages/Assets.xaml", UriKind.Relative)),
                    new MenuItem("Управление оборудованием", "Управление оборудованием", new Uri("Pages/HardwareControl.xaml", UriKind.Relative)),
                    new MenuItem("CRM", "CRM", new Uri("Pages/CRM.xaml", UriKind.Relative))
                }
            );

            User.DefaultIcon = new BitmapImage(new Uri("pack://application:,,,/Resources/default.jpg"));
        }

        public MainWindow()
        {
            InitializeComponent();
            m_usersRepository = new SqlUsersRepository();

            UsersCmbBx.ItemsSource = m_usersRepository.GetAllUsers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = (Button)sender;
            var item = (MenuItem)menuItem.Tag;

            TitleTextBlc.Text = item.Description;
            this.Title = item.Description;

            PageFrame.Navigate(item.Uri);
        }

        private void UsersCmbBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentUser = (User)UsersCmbBx.SelectedItem;
        }


        private static Dictionary<string, MenuItem[]> m_menuItems;
        private UsersRepository m_usersRepository;

        private User? CurrentUser
        {
            get => m_currentUser;
            set
            {
                m_currentUser = value;

                if (value != null)
                {
                    UserImgBorder.Background = new ImageBrush(value.Icon);
                    if (m_menuItems.ContainsKey(value.Role))
                        MenuItems.ItemsSource = m_menuItems[value.Role];
                    else
                        MessageBox.Show("Роль пользователя не найдена");
                }

                TitleTextBlc.Text = String.Empty;
                PageFrame.Content = String.Empty;
            }
        }

        private User? m_currentUser;
    }
}
