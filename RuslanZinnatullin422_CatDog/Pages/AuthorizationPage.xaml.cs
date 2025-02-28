using Microsoft.Win32;
using RuslanZinnatullin422_CatDog.DataBase;
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
using System.Windows.Shapes;

namespace RuslanZinnatullin422_CatDog.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Window
    {
      
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            User user = App.db.User.FirstOrDefault(x => x.Login == LoginTbl.Text && x.Password == PasswordBox.Password);
            if (user != null)
            {
                if(user.FirstName == "Деля")
                {
                    App.id_user = 2;
                    App.main.myframe.NavigationService.Navigate(new Pages.PetList());
                }
                else if(user.FirstName == "Андрей")
                {
                    App.id_user = 1;
                    App.main.myframe.NavigationService.Navigate(new Pages.PetList());
                }
            }
            else
            {
                MessageBox.Show("нет");
            }
        }
    }
}
