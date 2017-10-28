using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;

namespace My_graphics_editor
{
    class Appearance
    {
        Canvas canvas;
        Random random = new Random();
        int CountEllipse = 0;

        public void Set_Canvas(Canvas canvas)
        {
            this.canvas =canvas;
        }

        public void Modif_Shape_Group1(Shape shape)
        {
             CountEllipse++;
            shape.Name = "Ellipse"+Convert.ToString(CountEllipse);
            shape.Width = 50;
            shape.Height = 50;
            shape.Stroke = Brushes.Red;
            shape.StrokeThickness = 3;
            shape.Fill = Brushes.Black;

            Canvas.SetLeft(shape, random.Next(0, (int)(canvas.ActualWidth - 2 * shape.Width)));
            Canvas.SetTop(shape, random.Next(0, (int)(canvas.ActualHeight - 2 * shape.Height)));
        }

        public void Modif_Shape_Group2(Polygon polygon)
        {
            Random randomTreangleЗlace = new Random();
            int scale = 2;
            if (randomTreangleЗlace.Next(3) == 0)
            {
                polygon.Points = new PointCollection() { new Point(10 * scale, 10 * scale), new Point(60 * scale, 10 * scale), new Point(10 * scale, 60 * scale) };
            }
            if (randomTreangleЗlace.Next(3) == 1)
            {
                polygon.Points = new PointCollection() { new Point(40 * scale, 10 * scale), new Point(10 * scale, 40 * scale), new Point(70 * scale, 40 * scale) };
            }
            else
            {
                polygon.Points = new PointCollection() { new Point(10 * scale, 10 * scale), new Point(60 * scale, 10 * scale), new Point(60 * scale, 60 * scale) };
            }
            polygon.Stroke = Brushes.Red;
            polygon.StrokeThickness = 3;
            polygon.Fill = Brushes.Black;

            Canvas.SetLeft(polygon, random.Next(0, (int)(canvas.ActualWidth) - 100));
            Canvas.SetTop(polygon, random.Next(0, (int)(canvas.ActualHeight) - 100));
        }
    }
}
