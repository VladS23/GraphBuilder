using Microsoft.Win32;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CanvasRoot canvasRoot = new CanvasRoot();
        public MainWindow()
        {
            InitializeComponent();
            Rectangle lbrd = new Rectangle();
            Grid.SetColumn(lbrd, 1);
            lbrd.Fill = new SolidColorBrush(Color.FromRgb(27, 49, 72));
            lbrd.Fill= new SolidColorBrush(Colors.LightGray);
            Canvas.SetZIndex(lbrd, 0);
            lbrd.Margin=new Thickness(0, 30, 1284, 10);
            MainGrid.Children.Add(lbrd);
            MainGrid.Children.Add(CanvasRoot.brd);
            CanvasRoot.Persons.Add(new Person(@"C:\Users\Vlad\Desktop\person.jpg", "Иванов", "Иван", "Иванович", 0, 100));
            CanvasRoot.Persons.Add(new Person(@"C:\Users\Vlad\Desktop\person.jpg", "Петров", "", "", 0, 300));
            CanvasRoot.Persons.Add(new Person(@"C:\Users\Vlad\Desktop\person.jpg", "Jonson", "Bob", "", 100, 400));
            CanvasRoot.Persons.Add(new Person(@"C:\Users\Vlad\Desktop\person.jpg", "Иванов", "Иван", "Иванович", 0, 200));
            CanvasRoot.Persons.Add(new Person(@"C:\Users\Vlad\Desktop\person.jpg", "Петров", "", "", 0, 400));
            CanvasRoot.Persons.Add(new Person(@"C:\Users\Vlad\Desktop\person.jpg", "Jonson", "Bob", "", 500, 400));
            CanvasRoot.Connections.Add(new Connection(CanvasRoot.Persons[0], CanvasRoot.Persons[2]));
            CanvasRoot.Connections.Add(new Connection(CanvasRoot.Persons[0], CanvasRoot.Persons[1]));
            CanvasRoot.Connections.Add(new Connection(CanvasRoot.Persons[1], CanvasRoot.Persons[2]));
            CanvasRoot.Connections.Add(new Connection(CanvasRoot.Persons[3], CanvasRoot.Persons[4]));
            CanvasRoot.Connections.Add(new Connection(CanvasRoot.Persons[4], CanvasRoot.Persons[1]));
        }
    }
}
