using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace GraphBuilder
{
    public class Connection
    {
        public Line l1 = new Line();
        public Person person1;
        public Person person2;
        public Connection(Person p1, Person p2)
        {
            person1 = p1;
            person2 = p2;
            Canvas.SetZIndex(l1, 0);
            l1.StrokeThickness = 2;
            l1.Stroke = System.Windows.Media.Brushes.Gray;
            l1.X1 = p1.X + 25;
            l1.Y1 = p1.Y+25;
            l1.X2 = p2.X+25;
            l1.Y2 = p2.Y+25;
            CanvasRoot.MainCanvas.Children.Add(l1);
        }
        public void UpdateConnection()
        {
            Person tempPerson;
            if (person1.view.Visibility == System.Windows.Visibility.Hidden && person2.view.Visibility == System.Windows.Visibility.Hidden)
            {
                l1.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (person1.view.Visibility == System.Windows.Visibility.Hidden || person2.view.Visibility == System.Windows.Visibility.Hidden)
            {
                l1.Visibility = System.Windows.Visibility.Visible;
                if (person1.view.Visibility == System.Windows.Visibility.Visible)
                {
                    l1.X1=person1.X;
                    l1.Y1=person1.Y;
                }
                if (person1.view.Visibility == System.Windows.Visibility.Visible)
                {
                    l1.X2 = person2.X;
                    l1.Y2 = person2.Y;
                }
                if (person2.view.Visibility == System.Windows.Visibility.Hidden)
                {
                    tempPerson = person1;
                    person1 = person2;
                    person2 = tempPerson;
                }
                double a = person1.Y + 25;
                double b = person2.Y + 25;
                double c = person1.X + 25;
                double d = person2.X + 25;
                double e = CanvasRoot.MainCanvas.ActualHeight;
                double f = CanvasRoot.MainCanvas.ActualWidth;
                if (person1.X<0)
                {
                    l1.X1 = 0;
                    l1.X2 = d;
                    l1.Y2 = b;
                    l1.Y1 = (b * c - a * d) / (c - d);
                }
                else if (person1.Y < 0)
                {
                    l1.Y1 = 0;
                    l1.X2 = d;
                    l1.Y2 = b;
                    l1.X1 = (a * d - b * c) / (a - b);
                }
                if (person1.X > f-person1.view.ActualWidth)
                {
                    l1.X1 = f;
                    l1.X2 = d;
                    l1.Y2 = b;
                    l1.Y1 = (-a*d+a*f+b*c-b*f)/(c-d);
                }
                if (person1.Y > e-person1.view.ActualHeight)
                {
                    l1.Y1 = e;
                    l1.X2 = d;
                    l1.Y2 = b;
                    l1.X1 = (a * d - b * c + c * e - d * e) / (a - b);
                }
            }
            else
            {
                this.l1.X1 = person1.X + 25;
                this.l1.Y1 = person1.Y + 25;
                this.l1.X2 = person2.X + 25;
                this.l1.Y2 = person2.Y + 25;
            }

        }
    }
}
