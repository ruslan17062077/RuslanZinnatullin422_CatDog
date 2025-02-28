using RuslanZinnatullin422_CatDog.DataBase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RuslanZinnatullin422_CatDog
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static RuslanZinnatullin422_CatDogEntities db = new RuslanZinnatullin422_CatDogEntities();
        public static MainWindow main;
        public static int id_user;
    }
}
