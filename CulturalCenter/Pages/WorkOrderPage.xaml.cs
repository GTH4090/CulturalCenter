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
    /// Логика взаимодействия для WorkOrderPage.xaml
    /// </summary>
    public partial class WorkOrderPage : Page
    {
        bool yes = false;
        public WorkOrderPage()
        {
            InitializeComponent();
        }

        private void LoadData()
        {

            try
            {
                if (yes)
                {
                    var workOrders = Db.WorkOrder.ToList();
                    if (DescriptionTbx.Text.Length > 0)
                    {
                        workOrders = workOrders.Where(el => el.Description.Contains(DescriptionTbx.Text)).ToList();
                    }
                    if (WorkTypeCbx.SelectedIndex != 0 && WorkTypeCbx.SelectedItem != null)
                    {
                        var item = WorkTypeCbx.SelectedItem as WorkType;
                        workOrders = workOrders.Where(el => el.WorkTypeId == item.Id).ToList();

                    }
                    workOrders = workOrders.Where(el => Convert.ToDateTime(el.DateStart) >= FromDp.SelectedDate
                    && Convert.ToDateTime(el.DateStart) <= ToDp.SelectedDate).ToList();
                    workOrderDataGrid.ItemsSource = workOrders;
                }


            }
            catch (Exception ex)
            {
                Error();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var items = Db.WorkType.ToList();
            items.Insert(0, new Models.WorkType() { Name = "Все" });
            WorkTypeCbx.ItemsSource = items;
            WorkTypeCbx.SelectedIndex = 0;
            FromDp.SelectedDate = DateTime.Now.AddDays(-14);
            ToDp.SelectedDate = DateTime.Now.AddDays(14);
            yes = true;
            LoadData();

        }

        private void DescriptionTbx_TextChanged(object sender, TextChangedEventArgs e)
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

        private void WorkTypeCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WorkOrderEdit(-1));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (workOrderDataGrid.SelectedItem != null)
                {
                    var item = workOrderDataGrid.SelectedItem as Models.WorkOrder;
                    if (MessageBox.Show("Вы уверены?", "Точно-точно?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        Db.WorkOrder.Remove(item);
                        Db.SaveChanges();
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                Error();
            }

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                if (workOrderDataGrid.SelectedItem != null)
                {
                    var item = workOrderDataGrid.SelectedItem as Models.WorkOrder;
                    NavigationService.Navigate(new WorkOrderEdit(item.Id));

                }
            }
            catch (Exception ex)
            {
                Error();
            }
        }



    }
}
