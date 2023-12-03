using CulturalCenter.Models;
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
using static CulturalCenter.Classes.Helper;

namespace CulturalCenter.Pages
{
    /// <summary>
    /// Логика взаимодействия для FreeRoomsPage.xaml
    /// </summary>
    public partial class FreeRoomsPage : Page
    {
        public FreeRoomsPage()
        {
            InitializeComponent();
            DateDp.SelectedDate = DateTime.Now;
        }

        private void DateDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                var date = DateDp.SelectedDate.Value;
                var items = Db.Room.ToList().Where(el => el.RentRoom.FirstOrDefault(l => Convert.ToDateTime(l.DateStart) <= date && Convert.ToDateTime(l.DateEnd) >= date) == null).ToList();
                roomDataGrid.ItemsSource = items;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void RentBtn_Click(object sender, RoutedEventArgs e)
        {
            if(roomDataGrid.SelectedItem != null)
            {
                var item = roomDataGrid.SelectedItem as Room;
                NavigationService.Navigate(new RentRoomPage(item.Id, 2));
            }
        }
    }
}
