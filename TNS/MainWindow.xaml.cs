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

            CurrentUser = new User(0, new Phone("88005553535".ToCharArray()), new UserRole(5, "odmen"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = (Button)sender;
            var item = (MenuItem)menuItem.Tag;

            TitleTextBlc.Text = item.Description;

            PageFrame.Navigate(item.Uri);
        }



        private static MenuItem[][] m_menuItems;

        private User CurrentUser
        {
            get => m_currentUser;
            set
            {
                m_currentUser = value;

                MenuItems.ItemsSource = m_menuItems[value.Role.Id];
            }
        }
        private User m_currentUser = User.Empty;
    }
}
