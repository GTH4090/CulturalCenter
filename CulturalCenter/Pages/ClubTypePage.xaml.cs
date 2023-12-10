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
    /// Логика взаимодействия для ClubTypePage.xaml
    /// </summary>
    public partial class ClubTypePage : Page
    {
        public ClubTypePage()
        {
            InitializeComponent();
        }
        private void LoadData()
        {

            try
            {

                List<ClubType> statuses = Db.ClubType.ToList();

                if (DescriptionTbx.Text.Length > 0)
                {
                    statuses = statuses.Where(el => el.Name.Contains(DescriptionTbx.Text)).ToList();
                }

                ClubTypeDg.ItemsSource = statuses;



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
            NavigationService.Navigate(new ClubTypeEdit(-1));

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ClubTypeDg.SelectedItem != null)
                {
                    var item = ClubTypeDg.SelectedItem as ClubType;
                    NavigationService.Navigate(new ClubTypeEdit(item.Id));

                }
            }
            catch (Exception ex)
            {
                Error();
            }
        }

        

        private void DeleteBtn_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ClubTypeDg.SelectedItem != null)
                {
                    var item = ClubTypeDg.SelectedItem as ClubType;
                    if (MessageBox.Show("Вы уверены?", "Точно?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        try
                        {
                            Db.ClubType.Remove(item);
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
