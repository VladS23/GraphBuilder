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
    /// Логика взаимодействия для EditPersonWindow.xaml
    /// </summary>
    public partial class EditPersonWindow : Window
    {
        public Person person1;
        public EditPersonWindow(Person person)
        {
            InitializeComponent();
            person1 = person;
            PersonImagePrewiew.Source = person.PersonImage.Source;
            surnameTextBox.Text = person.PersonSurname;
            nameTextBox.Text = person.PersonName;
            patronymicTextBox.Text = person.PerssonPatronymic;
            Closebtn.PreviewMouseUp += CloseWindow;
            Savebtn.PreviewMouseUp += Save;
            ChangePhotoBtn.PreviewMouseUp += ChangePhoto;
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
                    myBitmapImage.UriSource = new Uri(openFileDialog.FileName);
                    myBitmapImage.EndInit();
                    PersonImagePrewiew.Source = myBitmapImage;
                    PersonImagePrewiew.Stretch = Stretch.Fill;
                }
                catch
                {

                }
            }
        }

        private void Save(object sender, MouseButtonEventArgs e)
        {
            person1.PersonImage.Source = PersonImagePrewiew.Source;
            person1.PersonSurname = surnameTextBox.Text;
            person1.PersonName = nameTextBox.Text;
            person1.PerssonPatronymic=patronymicTextBox.Text;
            person1.ViewUpdate();
            Close();
        }

        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
