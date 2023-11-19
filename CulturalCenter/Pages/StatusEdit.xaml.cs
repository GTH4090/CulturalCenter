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
    /// Логика взаимодействия для StatusEdit.xaml
    /// </summary>
    public partial class StatusEdit : Page
    {
        long _id;
        public StatusEdit(long id)
        {
            InitializeComponent();
            _id = id;   
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_id == -1)
                {
                    Db.Status.Add(grid1.DataContext as Status);
                }
                Db.SaveChanges();
                NavigationService.GoBack();
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_id == -1)
                {
                    grid1.DataContext = new Status();
                }
                else
                {
                    grid1.DataContext = Db.Status.FirstOrDefault(el => el.Id == _id);
                }
            }
            catch (Exception ex)
            {
                Error();
            }
        }
    }
}
