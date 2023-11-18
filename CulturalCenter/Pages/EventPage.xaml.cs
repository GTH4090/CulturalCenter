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
    /// Логика взаимодействия для EventPage.xaml
    /// </summary>
    public partial class EventPage : Page
    {
        bool yes = false;
        public EventPage()
        {
            InitializeComponent();
        }
        private void LoadData()
        {

            try
            {
                if (yes)
                {
                    List<Event> events = Db.Event.ToList();
                    if (EventTypeCbx.SelectedIndex != 0 && EventTypeCbx.SelectedItem != null)
                    {
                        var item = EventTypeCbx.SelectedItem as EventType;
                        events = events.Where(el => el.EventTypeId == item.Id).ToList();
                    }
                    if (DescriptionTbx.Text.Length > 0)
                    {
                        events = events.Where(el => el.Description.Contains(DescriptionTbx.Text)).ToList();
                    }
                    events = events.Where(el => Convert.ToDateTime(el.Date) >= FromDp.SelectedDate && Convert.ToDateTime(el.Date) <= ToDp.SelectedDate).ToList();
                    EventDg.ItemsSource = events;
                }
                

            }
            catch (Exception ex)
            {
                Error();
            }
        }

        private void DescriptionTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
        }

        private void EventTypeCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        private void FromDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        private void ToDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EventEdit(-1));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EventDg.SelectedItem != null)
            {
                var item = EventDg.SelectedItem as Event;
                NavigationService.Navigate(new EventEdit(item.Id));
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(EventDg.SelectedItem != null)
            {
                var item = EventDg.SelectedItem as Event;
                if(MessageBox.Show("Вы уверены?", "Точно?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    try
                    {
                        Db.Event.Remove(item);
                        Db.SaveChanges();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        Error();
                    }
                    
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                var items = Db.EventType.ToList();
                items.Insert(0, new EventType() { Name = "Все" });
                EventTypeCbx.ItemsSource = items;
                EventTypeCbx.SelectedIndex = 0;
                FromDp.SelectedDate = DateTime.Now.AddDays(-14);
                ToDp.SelectedDate = DateTime.Now.AddDays(14);
                yes = true;
                LoadData();
            }
            catch (Exception ex)
            {
                Error();
            }
            
        }
    }
}
