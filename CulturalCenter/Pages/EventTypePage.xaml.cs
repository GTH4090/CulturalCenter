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
    /// Логика взаимодействия для EventTypePage.xaml
    /// </summary>
    public partial class EventTypePage : Page
    {
        public EventTypePage()
        {
            InitializeComponent();
        }

        private void LoadData()
        {

            try
            {
                
                    List<EventType> events = Db.EventType.ToList();
                   
                    if (DescriptionTbx.Text.Length > 0)
                    {
                        events = events.Where(el => el.Name.Contains(DescriptionTbx.Text)).ToList();
                    }
                    
                    EventDg.ItemsSource = events;
                


            }
            catch (Exception ex)
            {
                Error();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void DescriptionTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EventTypeEdit(-1));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (EventDg.SelectedItem != null)
                {
                    var item = EventDg.SelectedItem as EventType;
                    NavigationService.Navigate(new EventTypeEdit(item.Id));

                }
            }
            catch (Exception ex)
            {
                Error();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (EventDg.SelectedItem != null)
                {
                    var item = EventDg.SelectedItem as EventType;
                    if (MessageBox.Show("Вы уверены?", "Точно?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        try
                        {
                            Db.EventType.Remove(item);
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
            catch (Exception ex)
            {
                Error();
            }
            
        }
    }
}
