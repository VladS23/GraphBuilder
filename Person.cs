using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GraphBuilder
{
     public class Person
    {
        private double x = 0;
        private double y = 0;
        private TextBlock surnameTextBlock = new TextBlock();
        private TextBlock nameTextBlock = new TextBlock();
        private TextBlock patronymicTextBlock = new TextBlock();
        public static bool isMousePressedinPerson = false;
        public StackPanel view = new StackPanel();
        public Image PersonImage = new Image();
        public string PersonName;
        public string PersonSurname;
        public string PerssonPatronymic;
        public double X
        {
            get { return x; }
            set { x = value; Canvas.SetLeft(view, value); }
        }
        public double Y
        {
            get { return y; }
            set { y = value; Canvas.SetTop(view, value); }
        }
        public Person(string imageadr, string surname, string name, string patronymic, double Xpos, double Ypos)
        {
            PersonName = name;
            PersonSurname= surname;
            PerssonPatronymic= patronymic; 
            StackPanel mystackPanel = new StackPanel();
            Button myButton = new Button();
            BitmapImage myBitmapImage = new BitmapImage();
            surnameTextBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            nameTextBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            patronymicTextBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            surnameTextBlock.Foreground = new SolidColorBrush(Colors.LightGray);
            nameTextBlock.Foreground = new SolidColorBrush(Colors.LightGray);
            patronymicTextBlock.Foreground = new SolidColorBrush(Colors.LightGray);
            surnameTextBlock.Text = surname;
            nameTextBlock.Text = name;
            patronymicTextBlock.Text = patronymic;
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(@imageadr);
            myBitmapImage.EndInit();
            PersonImage.Source = myBitmapImage;
            PersonImage.Stretch = Stretch.Fill;
            myButton.Content = PersonImage;
            myButton.Width = 50;
            myButton.Height = 50;
            X = Xpos;
            Y = Ypos;
            Canvas.SetLeft(mystackPanel, X);
            Canvas.SetTop(mystackPanel, Y);
            mystackPanel.Children.Add(myButton);
            if (surnameTextBlock.Text.Length > 0)
            {
                mystackPanel.Children.Add(surnameTextBlock);
            }
            if (nameTextBlock.Text.Length > 0)
            {
                mystackPanel.Children.Add(nameTextBlock);
            }
            if (patronymicTextBlock.Text.Length > 0)
            {
                mystackPanel.Children.Add(patronymicTextBlock);
            }
            view = mystackPanel;
            Canvas.SetZIndex(view, 150);
            CanvasRoot.MainCanvas.Children.Add(view);
            myButton.PreviewMouseMove += OnMouseMove;
            myButton.PreviewMouseLeftButtonUp += OnMouseUp;
            myButton.PreviewMouseLeftButtonDown += OnMouseDown;
            myButton.PreviewMouseDoubleClick += OnDobleClick;
        }
        public void ViewUpdate()
        {
            surnameTextBlock.Text = PersonSurname;
            nameTextBlock.Text = PersonName;
            patronymicTextBlock.Text = PerssonPatronymic;
        }

        private void OnDobleClick(object sender, MouseButtonEventArgs e)
        {
            EditPersonWindow editPerson = new EditPersonWindow(this);
            editPerson.Show();
        }

        System.Windows.Point pressedPos;
        System.Windows.Point curPos;
        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            isMousePressedinPerson = true;
            pressedPos = e.GetPosition((System.Windows.IInputElement)view.Parent);
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            isMousePressedinPerson = false;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            curPos = e.GetPosition((System.Windows.IInputElement)view.Parent);
            if (isMousePressedinPerson)
            {
                foreach (Connection connection in CanvasRoot.Connections)
                {
                    if (connection.person1==this || connection.person2 == this)
                    {
                        connection.UpdateConnection();
                    }
                }
                X = X + curPos.X - pressedPos.X;
                Y = Y + curPos.Y - pressedPos.Y;
                if (X < 0)
                {
                    X = 0;
                }
                else if (Y < 0)
                {
                    Y = 0;
                }
                else if (Y > CanvasRoot.MainCanvas.ActualHeight-view.ActualHeight)
                {
                    Y = CanvasRoot.MainCanvas.ActualHeight- view.ActualHeight;
                }
                else if (X > CanvasRoot.MainCanvas.ActualWidth-view.ActualWidth)
                {
                    X = CanvasRoot.MainCanvas.ActualWidth- view.ActualWidth;
                }
            }
            pressedPos = curPos;
        }
    }
}

