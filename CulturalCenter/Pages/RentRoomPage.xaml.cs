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
        public RentRoomPage(long id = -1, int type = -1)
        {
            _id = id;
            _type = type;
            InitializeComponent();
        }

        private void EventCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void StartDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EndDp.DisplayDateStart = StartDp.SelectedDate.Value;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EndDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            StartDp.DisplayDateEnd = EndDp.SelectedDate.Value;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            EventCbx.ItemsSource = Db.Event.ToList();
            EventCbx.SelectedIndex = 0;
            StartDp.SelectedDate = DateTime.Now.AddDays(-1);
            EndDp.SelectedDate  =DateTime.Now.AddDays(1);
            if(_type == 1)
            {
                EventCbx.SelectedItem = Db.Event.FirstOrDefault(el => el.Id == _id);
            }
            if (_type == 2) 
            {
                RoomCbx.ItemsSource = Db.Room.ToList();
                RoomCbx.SelectedItem = Db.Room.FirstOrDefault(el => el.Id == _id);
            }
        }
    }
}
