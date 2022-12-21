using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace GraphBuilder
{
    public class CanvasRoot
    {
        public static double createdPersonX;
        public static  double createdPersonY;
        public static List<Person> Persons = new List<Person>();
        public static List<Connection> Connections = new List<Connection>();
        public static Canvas MainCanvas = new Canvas();
        public static Border brd = new Border();
        public static bool isMousePressedinPerson = false;
        public CanvasRoot()
        {
            brd.Background = new SolidColorBrush(Color.FromRgb(69,94,131));
            brd.CornerRadius = new CornerRadius(3);
            brd.Margin = new Thickness(30, 30, 30, 30);
            brd.BorderBrush = new SolidColorBrush(Colors.White);
            brd.BorderThickness = new Thickness(1);
            MainCanvas.Margin = new Thickness(10, 10, 10, 10);
            MainCanvas.Background = new SolidColorBrush(Color.FromRgb(69, 94, 131));
            ContextMenu canvasMenu = new ContextMenu();
            MenuItem createPerson = new MenuItem();
            createPerson.Header = "Create a person";
            canvasMenu.Items.Add(createPerson);
            MainCanvas.ContextMenu = canvasMenu;
            brd.Child = MainCanvas;
            Grid.SetColumn(brd, 1);
            createPerson.PreviewMouseUp += CreatePersonMenuOpen;
            MainCanvas.PreviewMouseMove += OnMouseMove;
            MainCanvas.PreviewMouseLeftButtonUp += OnMouseUp;
        }

        private void CreatePersonMenuOpen(object sender, MouseButtonEventArgs e)
        {
            CreatePersonWindow createPersonWindov = new CreatePersonWindow();
            createdPersonX= e.GetPosition((System.Windows.IInputElement)CanvasRoot.MainCanvas).X;
            createdPersonY = e.GetPosition((System.Windows.IInputElement)CanvasRoot.MainCanvas).Y;
            createPersonWindov.Show();
        }
        bool isMousePressed = false;
        System.Windows.Point pressedPos;
        System.Windows.Point curPos;
        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!Person.isMousePressedinPerson)
            {
                isMousePressed = false;
            }
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (!Person.isMousePressedinPerson)
            {
                curPos = e.GetPosition(MainCanvas);
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    foreach (Person person in Persons)
                    {
                        person.X = person.X + curPos.X - pressedPos.X;
                        person.Y = person.Y + curPos.Y - pressedPos.Y;
                        
                        if (person.X < -50 || person.Y < -75 || person.X > MainCanvas.ActualWidth - person.view.ActualWidth+75
                            || person.Y > MainCanvas.ActualHeight - person.view.ActualHeight+75)
                        {
                            //person.view.Visibility = Visibility.Hidden;
                        }
                        if (person.X > -50 && person.Y > -75 && person.X < MainCanvas.ActualWidth - person.view.ActualWidth+75 &&
                            person.Y < MainCanvas.ActualHeight - person.view.ActualHeight+75
                            && person.view.Visibility == Visibility.Hidden)
                        {
                            person.view.Visibility = Visibility.Visible;
                        }
                    }
                    foreach (Connection connection in Connections)
                    {
                        connection.UpdateConnection();
                       /* if (connection.person1.view.Visibility == Visibility.Hidden || connection.person2.view.Visibility == Visibility.Hidden)
                        {
                            connection.l1.Visibility = Visibility.Hidden;
                        }
                        if (connection.person1.view.Visibility == Visibility.Visible && connection.person2.view.Visibility == Visibility.Visible)
                        {
                            connection.l1.Visibility = Visibility.Visible;
                        }*/
                    }
                }
                pressedPos = curPos;
            }
        }
        public void AddToCanvas(StackPanel view)
        {
            MainCanvas.Children.Add(view);
        }
    }
}
