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
    class AdditionalShapes
    {
        Shape shape;
        Canvas canvas;
        Random random = new Random();

        public AdditionalShapes(Shape shape, Canvas canvas)
        {
            this.shape = shape;
            this.canvas = canvas;
            if (shape.GetType() == typeof(Ellipse))
            {
                createAdditionalforELL();
            }
            if(shape.GetType() == typeof(Rectangle))
            {
                createAdditionalforRECT();
            }
        }

        public void createAdditionalforELL()
        {
            Ellipse topell = new Ellipse();
            TopPoint(topell);
            Ellipse downell = new Ellipse();
            DownPoint(downell);
            Ellipse leftell = new Ellipse();
            LeftPoint(leftell);
            Ellipse rightell = new Ellipse();
            RightPoint(rightell);
        }

        public void createAdditionalforRECT()
        {
            Ellipse topell = new Ellipse();
            TopPoint(topell);
            Ellipse downell = new Ellipse();
            DownPoint(downell);
            Ellipse leftell = new Ellipse();
            LeftPoint(leftell);
            Ellipse rightell = new Ellipse();
            RightPoint(rightell);
            Rectangle topleftrect = new Rectangle();
            TopLeftPoint(topleftrect);
            Rectangle toprightrect = new Rectangle();
            TopRightPoint(toprightrect);
            Rectangle downleftrect = new Rectangle();
            DownRightPoint(downleftrect);
            Rectangle downrightrect = new Rectangle();
            DownLeftPoint(downrightrect);
        }

        public void TopPoint(Shape topell)
        {
            topell.Width = 13;
            topell.Height = 13;
            topell.Fill = Brushes.White;
            topell.Stroke = Brushes.Black;
            topell.StrokeThickness = 2;
            canvas.Children.Add(topell);
            Canvas.SetTop(topell, Canvas.GetTop(shape) - (topell.Height) / 2);
            Canvas.SetLeft(topell, Canvas.GetLeft(shape) + (shape.Width / 2) - (topell.Width) / 2);
        }
        public void DownPoint(Shape topell)
        {
            topell.Width = 13;
            topell.Height = 13;
            topell.Fill = Brushes.White;
            topell.Stroke = Brushes.Black;
            topell.StrokeThickness = 2;
            canvas.Children.Add(topell);
            Canvas.SetTop(topell, Canvas.GetTop(shape) + ((shape.Height)) - (topell.Height / 2));
            Canvas.SetLeft(topell, Canvas.GetLeft(shape) + (shape.Width / 2) - (topell.Width) / 2);
        }
        public void LeftPoint(Shape topell)
        {
            topell.Width = 13;
            topell.Height = 13;
            topell.Fill = Brushes.White;
            topell.Stroke = Brushes.Black;
            topell.StrokeThickness = 2;
            canvas.Children.Add(topell);
            Canvas.SetTop(topell, Canvas.GetTop(shape) + ((shape.Height) / 2) - (topell.Height / 2));
            Canvas.SetLeft(topell, Canvas.GetLeft(shape) - (topell.Width) / 2);
        }
        public void RightPoint(Shape topell)
        {
            topell.Width = 13;
            topell.Height = 13;
            topell.Fill = Brushes.White;
            topell.Stroke = Brushes.Black;
            topell.StrokeThickness = 2;
            canvas.Children.Add(topell);
            Canvas.SetTop(topell, Canvas.GetTop(shape) + ((shape.Height) / 2) - (topell.Height / 2));
            Canvas.SetLeft(topell, Canvas.GetLeft(shape) + (shape.Width) - (topell.Width) / 2);
        }

        public void TopLeftPoint(Shape topell)
        {
            topell.Width = 10;
            topell.Height = 10;
            topell.Fill = Brushes.White;
            topell.Stroke = Brushes.Black;
            topell.StrokeThickness = 2;
            canvas.Children.Add(topell);
            Canvas.SetTop(topell, Canvas.GetTop(shape) - (topell.Height) / 2);
            Canvas.SetLeft(topell, Canvas.GetLeft(shape) - (topell.Width) / 2);
        }
        public void TopRightPoint(Shape topell)
        {
            topell.Width = 10;
            topell.Height = 10;
            topell.Fill = Brushes.White;
            topell.Stroke = Brushes.Black;
            topell.StrokeThickness = 2;
            canvas.Children.Add(topell);
            Canvas.SetTop(topell, Canvas.GetTop(shape) - (topell.Height) / 2);
            Canvas.SetLeft(topell, Canvas.GetLeft(shape) + (shape.Width) - (topell.Width) / 2);
        }
        public void DownRightPoint(Shape topell)
        {
            topell.Width = 10;
            topell.Height = 10;
            topell.Fill = Brushes.White;
            topell.Stroke = Brushes.Black;
            topell.StrokeThickness = 2;
            canvas.Children.Add(topell);
            Canvas.SetTop(topell, Canvas.GetTop(shape) + (shape.Height) - (topell.Height) / 2);
            Canvas.SetLeft(topell, Canvas.GetLeft(shape) + (shape.Width) - (topell.Width) / 2);
        }
        public void DownLeftPoint(Shape topell)
        {
            topell.Width = 10;
            topell.Height = 10;
            topell.Fill = Brushes.White;
            topell.Stroke = Brushes.Black;
            topell.StrokeThickness = 2;
            canvas.Children.Add(topell);
            Canvas.SetTop(topell, Canvas.GetTop(shape) + (shape.Height) - (topell.Height) / 2);
            Canvas.SetLeft(topell, Canvas.GetLeft(shape) - (topell.Width) / 2);
        }
    }
}
