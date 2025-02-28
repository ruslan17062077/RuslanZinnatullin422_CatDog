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

namespace RuslanZinnatullin422_CatDog.Pages
{
    /// <summary>
    /// Логика взаимодействия для PetList.xaml
    /// </summary>
    public partial class PetList : Page
    {
        public PetList()
        {
            InitializeComponent();
            Poisk();
        }

        private void poisk_TextChanged(object sender, TextChangedEventArgs e)
        {

            Poisk();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.main.myframe.NavigationService.Navigate(new Pages.AddPet());
        }
        public void Poisk()
        {
            if (poisk.Text.Length != 0)
            {
                PsinaData.ItemsSource = null;
                PsinaData.ItemsSource = App.db.Pet.Where(x => x.Description.ToLower().Contains(poisk.Text.ToLower()) && x.IdUser == App.id_user).ToList();
            }
            else
            {
                PsinaData.ItemsSource = App.db.Pet.Where(x => x.IdUser == App.id_user).ToList();
            }
        }
    }
}
