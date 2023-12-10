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
    /// Логика взаимодействия для RentRoomPage.xaml
    /// </summary>
    public partial class RentRoomPage : Page
    {
        long _id;
        int _type;
        long _rentId;
        bool yes = false;
        public RentRoomPage(long id = -1, int type = -1, long RentId = -1)
        {
            _id = id;
            _type = type;
            _rentId = RentId;
            InitializeComponent();
            
            if(_rentId == -1)
            {
                MainGrid.DataContext = new RentRoom();

            }
            else
            {
                MainGrid.DataContext = Db.RentRoom.FirstOrDefault(el => el.Id == _rentId);
            }
        }

        private void EventCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void loadRooms()
        {

            try
            {
                if (yes)
                {
                    DateTime start = StartDp.SelectedDate.Value;
                    DateTime end = EndDp.SelectedDate.Value;
                    var items = Db.Room.ToList();
                    var rents = Db.RentRoom.ToList();
                    items = items.Where(el => el.RentRoom.FirstOrDefault(l => (Convert.ToDateTime(l.DateStart) >= start && Convert.ToDateTime(l.DateStart) <= end) 
                    || (Convert.ToDateTime(l.DateStart) < start && Convert.ToDateTime(l.DateEnd) >= start)) == null).ToList();

                    RoomCbx.ItemsSource = items;
                    

                }

            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }


        private void StartDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = StartDp.SelectedDate;
            EndDp.DisplayDateStart = item;
            loadRooms();

        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                (MainGrid.DataContext as RentRoom).CreationDate = DateTime.Now.ToString();
                var start = StartDp.SelectedDate.Value;
                var end = EndDp.SelectedDate.Value;
                (MainGrid.DataContext as RentRoom).DateStart = new DateTime(start.Year, start.Month, start.Day, Convert.ToInt32(StartTimeTbx.Text.Split(':')[0]), Convert.ToInt32(StartTimeTbx.Text.Split(':')[1]), 0).ToString();
                (MainGrid.DataContext as RentRoom).DateEnd = new DateTime(end.Year, end.Month, end.Day, Convert.ToInt32(EndTimeTbx.Text.Split(':')[0]), Convert.ToInt32(EndTimeTbx.Text.Split(':')[1]), 0).ToString();
                if(_rentId == -1)
                {
                    Db.RentRoom.Add(MainGrid.DataContext as RentRoom);

                }
                Db.SaveChanges();
                NavigationService.GoBack();

            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void EndDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = EndDp.SelectedDate;
            StartDp.DisplayDateEnd = item;
            loadRooms();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            EventCbx.ItemsSource = Db.Event.ToList();
            if(_rentId == -1)
            {
                EventCbx.SelectedIndex = 0;
                StartDp.SelectedDate = DateTime.Now.AddDays(-1);
                EndDp.SelectedDate = DateTime.Now.AddDays(1);
            }
            else
            {
                StartDp.SelectedDate = Convert.ToDateTime((MainGrid.DataContext as RentRoom).DateStart).Date;
                EndDp.SelectedDate = Convert.ToDateTime((MainGrid.DataContext as RentRoom).DateEnd).Date;
                StartTimeTbx.Text = Convert.ToDateTime((MainGrid.DataContext as RentRoom).DateStart).Hour + ":" + Convert.ToDateTime((MainGrid.DataContext as RentRoom).DateStart).Minute;
                EndTimeTbx.Text = Convert.ToDateTime((MainGrid.DataContext as RentRoom).DateEnd).Hour + ":" + Convert.ToDateTime((MainGrid.DataContext as RentRoom).DateEnd).Minute;
                EventCbx.SelectedItem = (MainGrid.DataContext as RentRoom).Event;
            }

            yes = true;
            
            if(_type == 1)
            {
                EventCbx.SelectedItem = Db.Event.FirstOrDefault(el => el.Id == _id);
            }
            if (_type == 2) 
            {
                RoomCbx.ItemsSource = Db.Room.ToList();
                RoomCbx.SelectedItem = Db.Room.FirstOrDefault(el => el.Id == _id);
                RoomCbx.IsEnabled = true;
            }
            else
            {
                
                
                if(_rentId == -1)
                {
                    loadRooms();
                    RoomCbx.SelectedIndex = 0;
                }
                else
                {
                    RoomCbx.ItemsSource = Db.Room.ToList();
                    RoomCbx.SelectedItem = (MainGrid.DataContext as RentRoom).Room;

                }
            }
            
            
        }
    }
}
