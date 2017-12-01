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

        Rectangle topleftrect = new Rectangle();
        Rectangle toprightrect = new Rectangle();
        Rectangle downleftrect = new Rectangle();
        Rectangle downrightrect = new Rectangle();

        bool IsCheked1 = false;
        bool IsCheked2 = false;
        bool IsCheked3 = false;
        bool IsCheked4 = false;

        Point pointMove;

        bool IsCheked21 = false;
        bool IsCheked22 = false;
        bool IsCheked23 = false;
        bool IsCheked24 = false;

        double deltaX = 0;
        double deltaY = 0;

        public Resize_Shape(Shape shape,Canvas canvas, Ellipse topell, Ellipse downell, Ellipse leftell, Ellipse rightell)
        {
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
        public Resize_Shape(Shape shape, Canvas canvas, Ellipse topell, Ellipse downell, Ellipse leftell, Ellipse rightell, Rectangle topleftrect, Rectangle toprightrect, Rectangle downleftrect, Rectangle downrightrect)
        {
            this.shape = shape;
            this.canvas = canvas;
            canvas.MouseLeftButtonDown += Canvas_MouseLeftButtonDown;
            canvas.MouseLeftButtonUp += Canvas_MouseLeftButtonUp;
            canvas.MouseMove += Canvas_MouseMove;
            this.topell = topell;
            this.downell = downell;
            this.leftell = leftell;
            this.rightell = rightell;
            this.topleftrect = topleftrect;
            this.toprightrect = toprightrect;
            this.downleftrect = downleftrect;
            this.downrightrect = downrightrect;
        }

        public void Remove_Mouse_Event()
        {

            canvas.MouseLeftButtonDown -= Canvas_MouseLeftButtonDown;
            canvas.MouseLeftButtonUp -= Canvas_MouseLeftButtonUp;
            canvas.MouseMove -= Canvas_MouseMove;
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.GetPosition(canvas).X < Canvas.GetLeft(topell) + topell.Width && e.GetPosition(canvas).X > Canvas.GetLeft(topell) && e.GetPosition(canvas).Y > Canvas.GetTop(topell) && e.GetPosition(canvas).Y < Canvas.GetTop(topell) + topell.Height)
            {
                IsCheked1 = true;
                pointMove.X = Canvas.GetLeft(topell);
                pointMove.Y = Canvas.GetTop(topell);
                deltaX = e.GetPosition(canvas).X - Canvas.GetLeft(topell);
                deltaY = e.GetPosition(canvas).Y - Canvas.GetTop(topell);
            }
            if (e.GetPosition(canvas).X < Canvas.GetLeft(downell) + downell.Width && e.GetPosition(canvas).X > Canvas.GetLeft(downell) && e.GetPosition(canvas).Y > Canvas.GetTop(downell) && e.GetPosition(canvas).Y < Canvas.GetTop(downell) + downell.Height)
            {
                IsCheked2 = true;
                pointMove.X = Canvas.GetLeft(downell);
                pointMove.Y = Canvas.GetTop(downell);
                deltaX = e.GetPosition(canvas).X - Canvas.GetLeft(downell);
                deltaY = e.GetPosition(canvas).Y - Canvas.GetTop(downell);
            }
            if (e.GetPosition(canvas).X < Canvas.GetLeft(rightell) + rightell.Width && e.GetPosition(canvas).X > Canvas.GetLeft(rightell) && e.GetPosition(canvas).Y > Canvas.GetTop(rightell) && e.GetPosition(canvas).Y < Canvas.GetTop(rightell) + rightell.Height)
            {
                IsCheked3 = true;
                pointMove.X = Canvas.GetLeft(rightell);
                pointMove.Y = Canvas.GetTop(rightell);
                deltaX = e.GetPosition(canvas).X - Canvas.GetLeft(rightell);
                deltaY = e.GetPosition(canvas).Y - Canvas.GetTop(rightell);
            }
            if (e.GetPosition(canvas).X < Canvas.GetLeft(leftell) + leftell.Width && e.GetPosition(canvas).X > Canvas.GetLeft(leftell) && e.GetPosition(canvas).Y > Canvas.GetTop(leftell) && e.GetPosition(canvas).Y < Canvas.GetTop(leftell) + leftell.Height)
            {
                IsCheked4 = true;
                pointMove.X = Canvas.GetLeft(leftell);
                pointMove.Y = Canvas.GetTop(leftell);
                deltaX = e.GetPosition(canvas).X - Canvas.GetLeft(leftell);
                deltaY = e.GetPosition(canvas).Y - Canvas.GetTop(leftell);
            }
        }
        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IsCheked1 = false; IsCheked2 = false; IsCheked3 = false; IsCheked4 = false;

            if (IsCheked21)
            {
                shape.Height = shape.Height - (Canvas.GetTop(topell) - pointMove.Y);
                Canvas.SetTop(shape, e.GetPosition(canvas).Y - deltaY + (topell.Height / 2));

                Canvas.SetTop(rightell, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                Canvas.SetTop(leftell, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);

                IsCheked21 = false;
            }
            if (IsCheked22)
            {
                shape.Height = shape.Height + (Canvas.GetTop(downell) - pointMove.Y);

                Canvas.SetTop(rightell, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                Canvas.SetTop(leftell, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);

                IsCheked22 = false;
            }
            if (IsCheked23)
            {
                shape.Width = shape.Width + (Canvas.GetLeft(rightell) - pointMove.X);

                Canvas.SetLeft(topell, Canvas.GetLeft(shape) + shape.Width / 2 - topell.Width / 2);
                Canvas.SetLeft(downell, Canvas.GetLeft(shape) + shape.Width / 2 - downell.Width / 2);

                IsCheked23 = false;
            }
            if (IsCheked24)
            {
                shape.Width = shape.Width - (Canvas.GetLeft(leftell) - pointMove.X);
                Canvas.SetLeft(shape, e.GetPosition(canvas).X - deltaX + (leftell.Width / 2));

                Canvas.SetLeft(topell, Canvas.GetLeft(shape) + shape.Width / 2 - topell.Width / 2);
                Canvas.SetLeft(downell, Canvas.GetLeft(shape) + shape.Width / 2 - downell.Width / 2);

                IsCheked24 = false;
            }
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsCheked1)
            {
                Canvas.SetTop(topell, e.GetPosition(canvas).Y - deltaY);
                IsCheked21 = true;
            }
            if (IsCheked2)
            {
                Canvas.SetTop(downell, e.GetPosition(canvas).Y - deltaY);
                IsCheked22 = true;
            }
            if (IsCheked3)
            {
                Canvas.SetLeft(rightell, e.GetPosition(canvas).X - deltaX);
                IsCheked23 = true;
            }
            if (IsCheked4)
            {
                Canvas.SetLeft(leftell, e.GetPosition(canvas).X - deltaX);
                IsCheked24 = true;
            }
        }
    }
}
