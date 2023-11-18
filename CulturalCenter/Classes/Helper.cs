using CulturalCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CulturalCenter.Classes
{
    internal class Helper
    {
        public static mainEntities1 Db = new mainEntities1();
        public static void Error(string message = "Ошибка подключения к БД")
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
