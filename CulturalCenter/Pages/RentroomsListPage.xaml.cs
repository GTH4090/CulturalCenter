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
    /// Логика взаимодействия для RentroomsListPage.xaml
    /// </summary>
    public partial class RentroomsListPage : Page
    {
        public RentroomsListPage()
        {
            InitializeComponent();
            loadData();
        }
        private void loadData()
        {

            try
            {
                var items = Db.RentRoom.ToList();

                rentRoomDataGrid.ItemsSource = items;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RentRoomPage());
            loadData();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (rentRoomDataGrid.SelectedItem != null)
            {
                var items = rentRoomDataGrid.SelectedItem as RentRoom;
                NavigationService.Navigate(new RentRoomPage(-1, -1, items.Id));
                loadData();
            }

        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if(rentRoomDataGrid.SelectedItem != null)
                {
                    if(MessageBox.Show("Вы уверены?","Точно?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var items = rentRoomDataGrid.SelectedItem as RentRoom;
                        Db.RentRoom.Remove(items);
                        Db.SaveChanges();
                        loadData();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
    }
}
