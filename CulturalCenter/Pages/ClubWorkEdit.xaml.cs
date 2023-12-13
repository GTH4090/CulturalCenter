﻿using System;
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
    /// Логика взаимодействия для ClubWorkEdit.xaml
    /// </summary>
    public partial class ClubWorkEdit : Page
    {
        long _id;
        public ClubWorkEdit(long Id)
        {
            _id = Id;
            InitializeComponent();

            try
            {
                if (Id == -1)
                {
                    MainSp.DataContext = new ClubWork();

                }
                else
                {
                    MainSp.DataContext = Db.ClubWork.FirstOrDefault(el => el.Id == _id);
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
            
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if((MainSp.DataContext as ClubWork).Name != null )
                {
                    (MainSp.DataContext as ClubWork).DateStart = StartDateeDp.SelectedDate.Value.ToString("d");
                    if (_id == -1)
                    {
                        Db.ClubWork.Add(MainSp.DataContext as ClubWork);
                    }
                    Db.SaveChanges();
                    NavigationService.GoBack();
                }
                

            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ScheduleTypeCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                var item = ScheduleTypeCbx.SelectedItem as CheduleType;
                FirstGb.Visibility = Visibility.Collapsed;
                SecondGb.Visibility = Visibility.Collapsed;
                ThirdGb.Visibility = Visibility.Collapsed;
                if (item.Id == 3)
                {
                    FirstGb.Visibility = Visibility.Visible;
                    (MainSp.DataContext as ClubWork).WeekDay1 = null;
                    (MainSp.DataContext as ClubWork).WeekDay2 = null;
                }
                if (item.Id == 2)
                {
                    FirstGb.Visibility = Visibility.Visible;
                    SecondGb.Visibility = Visibility.Visible;
                    (MainSp.DataContext as ClubWork).WeekDay2 = null;

                }
                if (item.Id == 1)
                {
                    FirstGb.Visibility = Visibility.Visible;
                    SecondGb.Visibility = Visibility.Visible;
                    ThirdGb.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                FirstLessonCbx.ItemsSource = Db.WeekDay.ToList();
                SecondLessonCbx.ItemsSource = Db.WeekDay.ToList();
                ThirdLessonCbx.ItemsSource = Db.WeekDay.ToList();
                RoomCbx.ItemsSource = Db.Room.ToList();
                ScheduleTypeCbx.ItemsSource = Db.CheduleType.ToList();
                TypeCbx.ItemsSource = Db.ClubType.ToList();
                TeacherCbx.ItemsSource = Db.Teacher.ToList();
                if(_id == -1)
                {
                    TypeCbx.SelectedIndex = 0;
                    RoomCbx.SelectedIndex = 0;
                    ScheduleTypeCbx.SelectedIndex = 0;
                    StartDateeDp.SelectedDate = DateTime.Now;
                    TeacherCbx.SelectedIndex = 0;
                }
                else
                {
                    StartDateeDp.SelectedDate = Convert.ToDateTime((MainSp.DataContext as ClubWork).DateStart);
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
           

        }
    }
}
