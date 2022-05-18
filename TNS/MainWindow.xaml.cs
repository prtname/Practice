using Practice.DataAccess;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TNS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MainWindow()
        {
            m_menuItems = new MenuItem[][]
            {
                new MenuItem[]
                {
                    new MenuItem("Абоненты", "Абоненты ТНС", new Uri("Pages/Subscribers.xaml", UriKind.Relative)),
                    new MenuItem("CRM", "CRM", new Uri("Pages/CRM.xaml", UriKind.Relative)),
                    new MenuItem("Биллинг", "Биллинг", new Uri("Pages/Billing.xaml", UriKind.Relative)),
                },
                new MenuItem[]
                {
                    new MenuItem("Абоненты", "Абоненты ТНС", new Uri("Pages/Subscribers.xaml", UriKind.Relative)),
                    new MenuItem("CRM", "CRM", new Uri("Pages/CRM.xaml", UriKind.Relative)),
                },
                new MenuItem[]
                {
                    new MenuItem("Абоненты", "Абоненты ТНС", new Uri("Pages/Subscribers.xaml", UriKind.Relative)),
                    new MenuItem("Поддержка пользователей", "Поддержка пользователей", new Uri("Pages/Support.xaml", UriKind.Relative)),
                    new MenuItem("CRM", "CRM", new Uri("Pages/CRM.xaml", UriKind.Relative)),
                    new MenuItem("Управление оборудованием", "Управление оборудованием", new Uri("Pages/HardwareControl.xaml", UriKind.Relative))
                },
                new MenuItem[]
                {
                    new MenuItem("Абоненты", "Абоненты ТНС", new Uri("Pages/Subscribers.xaml", UriKind.Relative)),
                    new MenuItem("Поддержка пользователей", "Поддержка пользователей", new Uri("Pages/Support.xaml", UriKind.Relative)),
                    new MenuItem("CRM", "CRM", new Uri("Pages/CRM.xaml", UriKind.Relative)),
                    new MenuItem("Управление оборудованием", "Управление оборудованием", new Uri("Pages/HardwareControl.xaml", UriKind.Relative))
                },
                new MenuItem[]
                {
                    new MenuItem("Абоненты", "Абоненты ТНС", new Uri("Pages/Subscribers.xaml", UriKind.Relative)),
                    new MenuItem("Биллинг", "Биллинг", new Uri("Pages/Billing.xaml", UriKind.Relative)),
                    new MenuItem("Активы", "Активы", new Uri("Pages/Assets.xaml", UriKind.Relative))
                },
                new MenuItem[]
                {
                    new MenuItem("Абоненты", "Абоненты ТНС", new Uri("Pages/Subscribers.xaml", UriKind.Relative)),
                    new MenuItem("Поддержка пользователей", "Поддержка пользователей", new Uri("Pages/Support.xaml", UriKind.Relative)),
                    new MenuItem("CRM", "CRM", new Uri("Pages/CRM.xaml", UriKind.Relative)),
                    new MenuItem("Управление оборудованием", "Управление оборудованием", new Uri("Pages/HardwareControl.xaml", UriKind.Relative)),
                    new MenuItem("Биллинг", "Биллинг", new Uri("Pages/Billing.xaml", UriKind.Relative)),
                    new MenuItem("Активы", "Активы", new Uri("Pages/Assets.xaml", UriKind.Relative))
                },
                new MenuItem[]
                {
                    new MenuItem("Абоненты", "Абоненты ТНС", new Uri("Pages/Subscribers.xaml", UriKind.Relative)),
                    new MenuItem("Активы", "Активы", new Uri("Pages/Assets.xaml", UriKind.Relative)),
                    new MenuItem("Управление оборудованием", "Управление оборудованием", new Uri("Pages/HardwareControl.xaml", UriKind.Relative)),
                    new MenuItem("CRM", "CRM", new Uri("Pages/CRM.xaml", UriKind.Relative))
                }
            };
        }

        public MainWindow()
        {
            InitializeComponent();
            User.DefaultIcon = new BitmapImage(new Uri("pack://application:,,,/Resources/default.jpg"));
            m_usersRepository = new ListUsersRepository();

            UsersCmbBx.ItemsSource = m_usersRepository.GetAllUsers();
            UsersCmbBx.SelectedItem = UsersCmbBx.Items[0];
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


        private static MenuItem[][] m_menuItems;
        private UsersRepository m_usersRepository;

        private User CurrentUser
        {
            get => m_currentUser;
            set
            {
                m_currentUser = value;

                MenuItems.ItemsSource = m_menuItems[value.Role.Id];
                TitleTextBlc.Text = String.Empty;
                PageFrame.Content = String.Empty;
            }
        }
        private User m_currentUser = User.Empty;

    }
}
