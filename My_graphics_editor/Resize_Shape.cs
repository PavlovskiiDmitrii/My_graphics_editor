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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace My_graphics_editor
{
    public class Resize_Shape
    {
        Shape shape;
        Canvas canvas;

        Ellipse topell = new Ellipse();
        Ellipse downell = new Ellipse();
        Ellipse leftell = new Ellipse();
        Ellipse rightell = new Ellipse();

        Xceed.Wpf.Toolkit.ColorPicker colorPicker;

        bool IsCheked_top = false;
        bool IsCheked_down = false;
        bool IsCheked_right = false;
        bool IsCheked_left = false;

        Point pointMove;

        public void Refresh_additionaal_Shapes(Shape shape)
        {

            Canvas.SetTop(topell, Canvas.GetTop(shape)-topell.Height / 2);
            Canvas.SetLeft(topell, Canvas.GetLeft(shape) + shape.Width / 2 - topell.Width / 2);
            
            Canvas.SetTop(downell, Canvas.GetTop(shape) + shape.Height - downell.Height / 2);
            Canvas.SetLeft(downell, Canvas.GetLeft(shape) + shape.Width / 2 - topell.Width / 2);

            Canvas.SetTop(rightell, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
            Canvas.SetLeft(rightell, Canvas.GetLeft(shape) + shape.Width - rightell.Width / 2);

            Canvas.SetTop(leftell, Canvas.GetTop(shape)+shape.Height/2 - topell.Height / 2);
            Canvas.SetLeft(leftell, Canvas.GetLeft(shape) - topell.Height / 2);
            

        }

        double deltaX = 0;
        double deltaY = 0;

        public Resize_Shape(Shape shape, Canvas canvas, Xceed.Wpf.Toolkit.ColorPicker colorPicker, Ellipse topell, Ellipse downell, Ellipse leftell, Ellipse rightell)
        {
            this.colorPicker = colorPicker;
            this.shape = shape;
            this.canvas = canvas;
            canvas.MouseLeftButtonDown += Canvas_MouseLeftButtonDown;
            canvas.MouseLeftButtonUp += Canvas_MouseLeftButtonUp;
            canvas.MouseMove += Canvas_MouseMove;
            this.topell = topell;
            this.downell = downell;
            this.leftell = leftell;
            this.rightell = rightell;
        }
      
        public void Remove_Mouse_Event()
        {
            canvas.MouseLeftButtonDown -= Canvas_MouseLeftButtonDown;
            canvas.MouseLeftButtonUp -= Canvas_MouseLeftButtonUp;
            canvas.MouseMove -= Canvas_MouseMove;
        }
        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(shape);
            if (e.GetPosition(canvas).X < Canvas.GetLeft(topell) + topell.Width && e.GetPosition(canvas).X > Canvas.GetLeft(topell) && e.GetPosition(canvas).Y > Canvas.GetTop(topell) && e.GetPosition(canvas).Y < Canvas.GetTop(topell) + topell.Height)
            {
                IsCheked_top = true;

                deltaX = e.GetPosition(canvas).X - Canvas.GetLeft(topell);
                deltaY = e.GetPosition(canvas).Y - Canvas.GetTop(topell);

                pointMove.X = Canvas.GetLeft(topell);
                pointMove.Y = Canvas.GetTop(topell);
            }
            if (e.GetPosition(canvas).X < Canvas.GetLeft(downell) + downell.Width && e.GetPosition(canvas).X > Canvas.GetLeft(downell) && e.GetPosition(canvas).Y > Canvas.GetTop(downell) && e.GetPosition(canvas).Y < Canvas.GetTop(downell) + downell.Height)
            {
                IsCheked_down = true;
                pointMove.X = Canvas.GetLeft(downell);
                pointMove.Y = Canvas.GetTop(downell);
                deltaX = e.GetPosition(canvas).X - Canvas.GetLeft(downell);
                deltaY = e.GetPosition(canvas).Y - Canvas.GetTop(downell);
            }
            if (e.GetPosition(canvas).X < Canvas.GetLeft(rightell) + rightell.Width && e.GetPosition(canvas).X > Canvas.GetLeft(rightell) && e.GetPosition(canvas).Y > Canvas.GetTop(rightell) && e.GetPosition(canvas).Y < Canvas.GetTop(rightell) + rightell.Height)
            {
                IsCheked_right = true;
                pointMove.X = Canvas.GetLeft(rightell);
                pointMove.Y = Canvas.GetTop(rightell);
                deltaX = e.GetPosition(canvas).X - Canvas.GetLeft(rightell);
                deltaY = e.GetPosition(canvas).Y - Canvas.GetTop(rightell);
            }
            if (e.GetPosition(canvas).X < Canvas.GetLeft(leftell) + leftell.Width && e.GetPosition(canvas).X > Canvas.GetLeft(leftell) && e.GetPosition(canvas).Y > Canvas.GetTop(leftell) && e.GetPosition(canvas).Y < Canvas.GetTop(leftell) + leftell.Height)
            {
                IsCheked_left = true;
                pointMove.X = Canvas.GetLeft(leftell);
                pointMove.Y = Canvas.GetTop(leftell);
                deltaX = e.GetPosition(canvas).X - Canvas.GetLeft(leftell);
                deltaY = e.GetPosition(canvas).Y - Canvas.GetTop(leftell);
            }
        }
        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            IsCheked_top = false; IsCheked_down = false; IsCheked_right = false; IsCheked_left = false;
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsCheked_top)
            {
                Canvas.SetTop(topell, e.GetPosition(canvas).Y - deltaY);

                shape.Height = shape.Height + pointMove.Y - Canvas.GetTop(topell);
                pointMove.Y = Canvas.GetTop(topell);
                Canvas.SetTop(shape, e.GetPosition(canvas).Y - deltaY + (topell.Height / 2));

                Canvas.SetTop(rightell, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                Canvas.SetTop(leftell, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);

            }
            if (IsCheked_down)
            {
                Canvas.SetTop(downell, e.GetPosition(canvas).Y - deltaY);

                shape.Height = shape.Height - (pointMove.Y - Canvas.GetTop(downell));
                pointMove.Y = Canvas.GetTop(downell);
                
                Canvas.SetTop(rightell, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                Canvas.SetTop(leftell, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);
            }
            if (IsCheked_right)
            {
                Canvas.SetLeft(rightell, e.GetPosition(canvas).X - deltaX);

                shape.Width = shape.Width - (pointMove.X - Canvas.GetLeft(rightell));
                pointMove.X = Canvas.GetLeft(rightell);

                Canvas.SetLeft(topell, Canvas.GetLeft(shape) + shape.Width / 2 - topell.Width / 2);
                Canvas.SetLeft(downell, Canvas.GetLeft(shape) + shape.Width / 2 - downell.Width / 2);

            }
            if (IsCheked_left)
            {
                Canvas.SetLeft(leftell, e.GetPosition(canvas).X - deltaX);

                shape.Width = shape.Width + pointMove.X - Canvas.GetLeft(leftell);
                pointMove.X = Canvas.GetLeft(leftell);

                Canvas.SetLeft(shape, e.GetPosition(canvas).X - deltaX + (leftell.Width / 2));

                Canvas.SetLeft(topell, Canvas.GetLeft(shape) + shape.Width / 2 - topell.Width / 2);
                Canvas.SetLeft(downell, Canvas.GetLeft(shape) + shape.Width / 2 - downell.Width / 2);


            }
        }


    }
}
