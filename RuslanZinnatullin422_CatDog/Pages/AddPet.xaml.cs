using Microsoft.Win32;
using RuslanZinnatullin422_CatDog.DataBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для AddPet.xaml
    /// </summary>
    public partial class AddPet : Page
    {
        private string photoPath;
        private BitmapImage img;
        private byte[] bytes;
        public AddPet()
        {
            InitializeComponent();
        }
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);
                    bytes = imageBytes;

                    // Отображаем изображение в интерфейсе
                    BitmapImage bitmap = new BitmapImage();
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        bitmap.BeginInit();
                        bitmap.StreamSource = ms;
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();
                        bitmap.Freeze();
                    }
                    PetImage.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(bytes.Length > 0 && PetNameComboBox.SelectedIndex != -1)
            {
                App.db.Pet.Add(new Pet()
                {
                    Name = (PetNameComboBox.SelectedItem as ComboBoxItem).Content.ToString(),
                    Description = DescriptionTextBox.Text,
                    Image = bytes,
                    IdUser = PetNameComboBox.SelectedIndex + 1

                });
                App.db.SaveChanges();
                App.main.myframe.NavigationService.Navigate(new Pages.PetList());
            }
            else
            {
                MessageBox.Show("Заполни инфу");
            }
            
              
            

          
            
        }
    }
}
