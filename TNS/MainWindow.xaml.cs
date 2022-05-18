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
        public MainWindow()
        {
            InitializeComponent();

            MenuItems.ItemsSource = new List<MenuItem> 
            { 
                new MenuItem("HHgg", "GGhh", new Uri("App.xaml", UriKind.Relative)),
                new MenuItem("AAAAAAAAAAAAAAABBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCC", "GGhh", new Uri("App.xaml", UriKind.Relative))
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = (Button)sender;
            var item = (MenuItem)menuItem.Tag;

            TitleTextBlc.Text = item.Description;

            //PageFrame.Navigate(uri);
        }
    }
}
