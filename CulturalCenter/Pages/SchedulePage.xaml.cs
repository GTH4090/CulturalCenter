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
    /// Логика взаимодействия для SchedulePage.xaml
    /// </summary>
    public partial class SchedulePage : Page
    {
        public SchedulePage()
        {
            InitializeComponent();
        }
        private void loadData()
        {

            try
            {
                var clubs = Db.ClubWork.ToList();
                for (int i = 0; i < clubs.Count; i++)
                {
                    MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
                    var item = clubs[i];
                    Label titleLb = new Label();
                    titleLb.Width = double.NaN;
                    titleLb.Content = item.Name;
                    Grid.SetColumn(titleLb, 0);
                    Grid.SetRow(titleLb, i + 1);
                    MainGrid.Children.Add(titleLb);
                    Border border = new Border();
                    border.BorderThickness = new Thickness(2);
                    border.BorderBrush = Brushes.Black;
                    border.Height = double.NaN;
                    border.Width = double.NaN;
                    Grid.SetRow(border, i + 1);
                    Grid.SetColumnSpan(border, 8);
                    MainGrid.Children.Add(border);
                    if(item.FirstLessonId != null)
                    {
                        Label firstlesLb = new Label();
                        firstlesLb.Content = $"{item.TimeStart}-{item.TimeEnd} \n {item.Room.Name} \n {item.Teacher.Name}";
                        firstlesLb.Width = double.NaN;
                        firstlesLb.Height = double.NaN;
                        Grid.SetRow(firstlesLb, i + 1);
                        Grid.SetColumn(firstlesLb, (int)item.FirstLessonId.Value);
                        MainGrid.Children.Add(firstlesLb);


                    }
                    if (item.SecondlessonId != null)
                    {
                        Label firstlesLb = new Label();
                        firstlesLb.Content = $"{item.TimeStart}-{item.TimeEnd} \n {item.Room.Name} \n {item.Teacher.Name}";
                        firstlesLb.Width = double.NaN;
                        firstlesLb.Height = double.NaN;
                        Grid.SetRow(firstlesLb, i + 1);
                        Grid.SetColumn(firstlesLb, (int)item.SecondlessonId.Value);
                        MainGrid.Children.Add(firstlesLb);


                    }
                    if (item.ThirdLessonId != null)
                    {
                        Label firstlesLb = new Label();
                        firstlesLb.Content = $"{item.TimeStart}-{item.TimeEnd} \n {item.Room.Name} \n {item.Teacher.Name}";
                        firstlesLb.Width = double.NaN;
                        firstlesLb.Height = double.NaN;
                        Grid.SetRow(firstlesLb, i + 1);
                        Grid.SetColumn(firstlesLb, (int)item.ThirdLessonId.Value);
                        MainGrid.Children.Add(firstlesLb);


                    }
                }
                
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();
        }
    }
}
