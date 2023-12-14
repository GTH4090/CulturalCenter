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

        private void WorkTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WorkTypePAge());
        }

        private void WorkOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.WorkOrderPage());

        }

        private void StatusBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StatusPage());
        }

        private void RoomsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RoomsPage());
        }

        private void DesktopBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DesktopPage());

        }

        private void RentBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RentroomsListPage());
        }

        private void FreeroomsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FreeRoomsPage());
        }

        private void TeacherBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeacherPage());
        }

        private void ClubTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClubTypePage());
        }

        private void ClubWorkBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClubWorka());
        }

        private void ScheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SchedulePage());
        }
    }
}
