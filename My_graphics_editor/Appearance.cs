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
    public class Appearance
    {
        Canvas canvas;
        Random random = new Random();
        int i = 1;

        public void Set_Canvas(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void SetAppearance(Shape shape)
        {
            if (shape.GetType() == typeof(Ellipse))
            {
                shape.Name = "Name_Ell_" + Convert.ToString(i);
                i++;
            }
            if (shape.GetType() == typeof(Rectangle))
            {
                shape.Name = "Name_Rec_" + Convert.ToString(i);
                i++;
            }
            shape.Stroke = Brushes.Black;
            shape.StrokeThickness = 3;
            shape.Fill = Brushes.Moccasin;

            if (shape.GetType() == typeof(Ellipse) || shape.GetType() == typeof(Rectangle))
            {
                shape.Width = 50;
                shape.Height = 50;
            }
        }
        public void SetCanvasPosition(Shape shape)
        {
            if (shape.GetType() == typeof(Ellipse) || shape.GetType() == typeof(Rectangle))
            {
                Canvas.SetLeft(shape, random.Next(0, (int)(canvas.ActualWidth - 2 * shape.Width)));
                Canvas.SetTop(shape, random.Next(0, (int)(canvas.ActualHeight - 2 * shape.Height)));
            }
            else
            {
                Canvas.SetLeft(shape, random.Next(0, (int)(canvas.ActualWidth) - 100));
                Canvas.SetTop(shape, random.Next(0, (int)(canvas.ActualHeight) - 100));
            }
        }

        public void Modif_Shape_Group1(Shape shape)
        {
            SetAppearance(shape);
            SetCanvasPosition(shape);
        }
        public void Modif_Shape_Group2(Polygon polygon)
        {
            Random randomTreangleЗlace = new Random();
            int scale = 2;
            polygon.Points = new PointCollection() { new Point(40 * scale, 10 * scale), new Point(10 * scale, 40 * scale), new Point(70 * scale, 40 * scale) };
            SetAppearance(polygon);
            SetCanvasPosition(polygon);
        }
    }
}
