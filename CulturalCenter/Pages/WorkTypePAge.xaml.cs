using CulturalCenter.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для WorkTypePAge.xaml
    /// </summary>
    public partial class WorkTypePAge : Page
    {
        public WorkTypePAge()
        {
            InitializeComponent();
        }
        private void LoadData()
        {

            try
            {

                List<WorkType> workTypes = Db.WorkType.ToList();

                if (DescriptionTbx.Text.Length > 0)
                {
                    workTypes = workTypes.Where(el => el.Name.Contains(DescriptionTbx.Text)).ToList();
                }

                WorkTypeDg.ItemsSource = workTypes;



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
            NavigationService.Navigate(new WorkTypeEdit(-1));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (WorkTypeDg.SelectedItem != null)
                {
                    var item = WorkTypeDg.SelectedItem as WorkType;
                    NavigationService.Navigate(new WorkTypeEdit(item.Id));

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
                if (WorkTypeDg.SelectedItem != null)
                {
                    var item = WorkTypeDg.SelectedItem as WorkType;
                    if (MessageBox.Show("Вы уверены?", "Точно?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        try
                        {
                            Db.WorkType.Remove(item);
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
