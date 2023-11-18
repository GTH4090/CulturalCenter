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
    /// Логика взаимодействия для EventEdit.xaml
    /// </summary>
    public partial class EventEdit : Page
    {
        long _id;
        public EventEdit(long id)
        {
            _id = id;
            InitializeComponent();
            if (_id == -1)
            {
                grid1.DataContext = new Event();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                eventTypeIdTextBox.ItemsSource = Db.EventType.ToList();
                if(_id == -1)
                {
                    eventTypeIdTextBox.SelectedIndex = 0;
                    dateDatePicker.SelectedDate = DateTime.Now;
                }
                else
                {
                    grid1.DataContext = Db.Event.FirstOrDefault(el => el.Id ==  _id);
                    dateDatePicker.SelectedDate = Convert.ToDateTime(Db.Event.FirstOrDefault(el => el.Id == _id).Date);
                }
            }
            catch (Exception ex)
            {
                Error();
            }
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                (grid1.DataContext as Event).Date = dateDatePicker.SelectedDate.ToString();
                if(_id == -1)
                {
                    Db.Event.Add(grid1.DataContext as Event);
                }
                Db.SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                Error();
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
