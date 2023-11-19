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
    /// Логика взаимодействия для DesktopPage.xaml
    /// </summary>
    public partial class DesktopPage : Page
    {
        public DesktopPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                workOrderDataGrid.ItemsSource = Db.WorkOrder.Where(el => el.StatusId == 2).ToList();
            }
            catch (Exception ex)
            {
                Error();
            }
        }
    }
}
