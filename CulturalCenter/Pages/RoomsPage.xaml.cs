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
    /// Логика взаимодействия для RoomsPage.xaml
    /// </summary>
    public partial class RoomsPage : Page
    {
        public RoomsPage()
        {
            InitializeComponent();
        }
        private void LoadData()
        {

            try
            {

                List<Room> rooms = Db.Room.ToList();

                if (DescriptionTbx.Text.Length > 0)
                {
                    rooms = rooms.Where(el => el.Name.Contains(DescriptionTbx.Text)).ToList();
                }

                RoomsDg.ItemsSource = rooms;



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
            NavigationService.Navigate(new RoomEdit(-1));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (RoomsDg.SelectedItem != null)
                {
                    var item = RoomsDg.SelectedItem as Room;
                    NavigationService.Navigate(new RoomEdit(item.Id));

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
                if (RoomsDg.SelectedItem != null)
                {
                    var item = RoomsDg.SelectedItem as Room;
                    if (MessageBox.Show("Вы уверены?", "Точно?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        try
                        {
                            Db.Room.Remove(item);
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
