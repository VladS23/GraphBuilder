using Microsoft.Win32;
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

namespace GraphBuilder
{
    /// <summary>
    /// Логика взаимодействия для CreatePersonWindow.xaml
    /// </summary>
    public partial class CreatePersonWindow : Window
    {
        string photoPath = "pack://application:,,,/Resourse/person.jpg";
        string surname = "";
        string name = "";
        string patronimyc = "";
        public CreatePersonWindow()
        {
            InitializeComponent();
            ChangePhotoBtn.PreviewMouseUp += ChangePhoto;
            CreatePersonBtn.PreviewMouseUp += CreatePerson;
        }

        private void CreatePerson(object sender, MouseButtonEventArgs e)
        {
            surname=surnameTextBox.Text;
            name=nameTextBox.Text;
            patronimyc=patronymicTextBox.Text;
            CanvasRoot.Persons.Add(new Person(photoPath, surname, name, patronimyc, CanvasRoot.createdPersonX, CanvasRoot.createdPersonY));
            this.Close();
        }

        private void ChangePhoto(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    BitmapImage myBitmapImage = new BitmapImage();
                    myBitmapImage.BeginInit();
                    photoPath = openFileDialog.FileName;
                    myBitmapImage.UriSource = new Uri(photoPath);
                    myBitmapImage.EndInit();
                    PersonImagePrewiew.Source = myBitmapImage;
                    PersonImagePrewiew.Stretch = Stretch.Fill;
                }
                catch
                {

                }
            }
        }
    }
}
