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

namespace CulturalCenter.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void EventBtn1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EventPage());
        }

        private void EventTypeBtn1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EventTypePage());
        }

        private void EventTypeBtn2_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new EventTypePage());
        }

        private void EventBtn2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EventPage());

        }
    }
}
