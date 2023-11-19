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
    /// Логика взаимодействия для StatusPage.xaml
    /// </summary>
    public partial class StatusPage : Page
    {
        public StatusPage()
        {
            InitializeComponent();
        }
        private void LoadData()
        {

            try
            {

                List<Status> statuses = Db.Status.ToList();

                if (DescriptionTbx.Text.Length > 0)
                {
                    statuses = statuses.Where(el => el.Name.Contains(DescriptionTbx.Text)).ToList();
                }

                StatusDg.ItemsSource = statuses;



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
            NavigationService.Navigate(new StatusEdit(-1));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (StatusDg.SelectedItem != null)
                {
                    var item = StatusDg.SelectedItem as Status;
                    NavigationService.Navigate(new StatusEdit(item.Id));

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
                if (StatusDg.SelectedItem != null)
                {
                    var item = StatusDg.SelectedItem as Status;
                    if (MessageBox.Show("Вы уверены?", "Точно?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        try
                        {
                            Db.Status.Remove(item);
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
