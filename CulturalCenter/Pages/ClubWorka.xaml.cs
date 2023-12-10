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
    /// Логика взаимодействия для ClubWorka.xaml
    /// </summary>
    public partial class ClubWorka : Page
    {
        public ClubWorka()
        {
            InitializeComponent();
        }
        private void LoadData()
        {

            try
            {

                List<ClubWork> statuses = Db.ClubWork.ToList();

                if (DescriptionTbx.Text.Length > 0)
                {
                    statuses = statuses.Where(el => el.Name.Contains(DescriptionTbx.Text)).ToList();
                }

                if(TypeCbx.SelectedIndex != 0 &&  TypeCbx.SelectedItem != null)
                {
                    var item = TypeCbx.SelectedItem as ClubType;
                    statuses = statuses.Where(el => el.ClubTipeId == item.Id).ToList();
                }
                if (RoomCbx.SelectedIndex != 0 && RoomCbx.SelectedItem != null)
                {
                    var item = RoomCbx.SelectedItem as Room;
                    statuses = statuses.Where(el => el.RoomId == item.Id).ToList();
                }

                clubWorkDataGrid.ItemsSource = statuses;



            }
            catch (Exception ex)
            {
                Error();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var rooms = Db.Room.ToList();
            rooms.Insert(0, new Room() { Name = "Все" });
            var clubTypes = Db.ClubType.ToList();
            clubTypes.Insert(0, new ClubType() { Name = "Все" });
            RoomCbx.ItemsSource = rooms;
            TypeCbx.ItemsSource = clubTypes;
            RoomCbx.SelectedIndex = 0;
            TypeCbx.SelectedIndex = 0;
            LoadData();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClubWorkEdit(-1));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (clubWorkDataGrid.SelectedItem != null)
                {
                    var item = clubWorkDataGrid.SelectedItem as ClubWork;
                    NavigationService.Navigate(new ClubWorkEdit(item.Id));

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
                if (clubWorkDataGrid.SelectedItem != null)
                {
                    var item = clubWorkDataGrid.SelectedItem as ClubWork;
                    if (MessageBox.Show("Вы уверены?", "Точно?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        try
                        {
                            Db.ClubWork.Remove(item);
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

        private void DescriptionTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
        }

        private void TypeCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        private void RoomCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }
    }
}
