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
using CulturalCenter.Models;

namespace CulturalCenter.Pages
{
    /// <summary>
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        public TeacherPage()
        {
            InitializeComponent();

        }
        private void LoadData()
        {

            try
            {

                List<Teacher> statuses = Db.Teacher.ToList();

                if (DescriptionTbx.Text.Length > 0)
                {
                    statuses = statuses.Where(el => el.Name.Contains(DescriptionTbx.Text)).ToList();
                }

                TeacherDg.ItemsSource = statuses;



            }
            catch (Exception ex)
            {
                Error();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeacherEdit(-1));
            

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TeacherDg.SelectedItem != null)
                {
                    var item = TeacherDg.SelectedItem as Teacher;
                    NavigationService.Navigate(new TeacherEdit(item.Id));

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
                if (TeacherDg.SelectedItem != null)
                {
                    var item = TeacherDg.SelectedItem as Teacher;
                    if (MessageBox.Show("Вы уверены?", "Точно?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        try
                        {
                            Db.Teacher.Remove(item);
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();

        }

        private void DescriptionTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();

        }
    }
}
