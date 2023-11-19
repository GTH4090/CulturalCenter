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
    /// Логика взаимодействия для WorkOrderEdit.xaml
    /// </summary>
    public partial class WorkOrderEdit : Page
    {
        long _id;
        public WorkOrderEdit(long id)
        {
            _id = id;
            InitializeComponent();
            if(id == -1)
            {
                grid1.DataContext = new Models.WorkOrder();
            }
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                (grid1.DataContext as Models.WorkOrder).DateStart = dateStartDp.SelectedDate.Value.ToString("d");
                (grid1.DataContext as Models.WorkOrder).DateEnd = dateEndDp.SelectedDate.Value.ToString("d");
                if(_id == -1)
                {
                    Db.WorkOrder.Add(grid1.DataContext as Models.WorkOrder);
                }
                Db.SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                Error();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                eventCbx.ItemsSource = Db.Event.ToList();
                roomCbx.ItemsSource = Db.Room.ToList();
                statusCbx.ItemsSource = Db.Status.ToList();
                workTypeCbx.ItemsSource = Db.WorkType.ToList();
                if(_id == -1)
                {
                    eventCbx.SelectedIndex = 0;
                    roomCbx.SelectedIndex = 0;
                    statusCbx.SelectedIndex = 0;
                    workTypeCbx.SelectedIndex = 0;
                    dateStartDp.SelectedDate = DateTime.Now;
                    dateEndDp.SelectedDate = DateTime.Now;
                }
                else
                {
                    var item = Db.WorkOrder.FirstOrDefault(el => el.Id == _id);
                    grid1.DataContext = item;
                    dateStartDp.SelectedDate = Convert.ToDateTime(item.DateStart);
                    dateEndDp.SelectedDate = Convert.ToDateTime(item.DateEnd);
                }

            }
            catch (Exception ex)
            {
                Error();
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
