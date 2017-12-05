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
    public class Resize_Rec
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

        Xceed.Wpf.Toolkit.ColorPicker colorPicker;

        bool IsCheked_top = false;
        bool IsCheked_down = false;
        bool IsCheked_right = false;
        bool IsCheked_left = false;

        bool IsCheked_top_1 = false;
        bool IsCheked_down_1 = false;
        bool IsCheked_right_1 = false;
        bool IsCheked_left_1 = false;

        Point pointMove;


        bool IsCheked_topleft = false;
        bool IsCheked_topright = false;
        bool IsCheked_downleft = false;
        bool IsCheked_downright = false;

        bool IsCheked_topleft_1 = false;
        bool IsCheked_topright_1 = false;
        bool IsCheked_downleft_1 = false;
        bool IsCheked_downright_1 = false;

        double deltaX = 0;
        double deltaY = 0;


        public Resize_Rec(Shape shape, Canvas canvas, Xceed.Wpf.Toolkit.ColorPicker colorPicker, Ellipse topell, Ellipse downell, Ellipse leftell, Ellipse rightell, Rectangle topleftrect, Rectangle toprightrect, Rectangle downleftrect, Rectangle downrightrect)
        {
            this.colorPicker = colorPicker;
            this.shape = shape;
            this.canvas = canvas;
            canvas.MouseLeftButtonDown += Canvas_MouseLeftButtonDown_rect;
            canvas.MouseLeftButtonUp += Canvas_MouseLeftButtonUp_rect;
            canvas.MouseMove += Canvas_MouseMove_rect;
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
            canvas.MouseLeftButtonDown -= Canvas_MouseLeftButtonDown_rect;
            canvas.MouseLeftButtonUp -= Canvas_MouseLeftButtonUp_rect;
            canvas.MouseMove -= Canvas_MouseMove_rect;
        }
        /// //////////////////////////////////////////
        private void Canvas_MouseLeftButtonDown_rect(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(shape);
            if (e.GetPosition(canvas).X < Canvas.GetLeft(topell) + topell.Width && e.GetPosition(canvas).X > Canvas.GetLeft(topell) && e.GetPosition(canvas).Y > Canvas.GetTop(topell) && e.GetPosition(canvas).Y < Canvas.GetTop(topell) + topell.Height)
            {
                IsCheked_top = true;
                pointMove.X = Canvas.GetLeft(topell);
                pointMove.Y = Canvas.GetTop(topell);
                deltaX = e.GetPosition(canvas).X - Canvas.GetLeft(topell);
                deltaY = e.GetPosition(canvas).Y - Canvas.GetTop(topell);
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
            //////////////////

            if (e.GetPosition(canvas).X < Canvas.GetLeft(topleftrect) + topleftrect.Width && e.GetPosition(canvas).X > Canvas.GetLeft(topleftrect) && e.GetPosition(canvas).Y > Canvas.GetTop(topleftrect) && e.GetPosition(canvas).Y < Canvas.GetTop(topleftrect) + topleftrect.Height)
            {
                IsCheked_topleft = true;
                pointMove.X = Canvas.GetLeft(topleftrect);
                pointMove.Y = Canvas.GetTop(topleftrect);
                deltaX = e.GetPosition(canvas).X - Canvas.GetLeft(topleftrect);
                deltaY = e.GetPosition(canvas).Y - Canvas.GetTop(topleftrect);
            }
            if (e.GetPosition(canvas).X < Canvas.GetLeft(toprightrect) + toprightrect.Width && e.GetPosition(canvas).X > Canvas.GetLeft(toprightrect) && e.GetPosition(canvas).Y > Canvas.GetTop(toprightrect) && e.GetPosition(canvas).Y < Canvas.GetTop(toprightrect) + toprightrect.Height)
            {
                IsCheked_topright = true;
                pointMove.X = Canvas.GetLeft(toprightrect);
                pointMove.Y = Canvas.GetTop(toprightrect);
                deltaX = e.GetPosition(canvas).X - Canvas.GetLeft(toprightrect);
                deltaY = e.GetPosition(canvas).Y - Canvas.GetTop(toprightrect);
            }
            if (e.GetPosition(canvas).X < Canvas.GetLeft(downleftrect) + downleftrect.Width && e.GetPosition(canvas).X > Canvas.GetLeft(downleftrect) && e.GetPosition(canvas).Y > Canvas.GetTop(downleftrect) && e.GetPosition(canvas).Y < Canvas.GetTop(downleftrect) + downleftrect.Height)
            {
                IsCheked_downleft = true;
                pointMove.X = Canvas.GetLeft(downleftrect);
                pointMove.Y = Canvas.GetTop(downleftrect);
                deltaX = e.GetPosition(canvas).X - Canvas.GetLeft(downleftrect);
                deltaY = e.GetPosition(canvas).Y - Canvas.GetTop(downleftrect);
            }
            if (e.GetPosition(canvas).X < Canvas.GetLeft(downrightrect) + downrightrect.Width && e.GetPosition(canvas).X > Canvas.GetLeft(downrightrect) && e.GetPosition(canvas).Y > Canvas.GetTop(downrightrect) && e.GetPosition(canvas).Y < Canvas.GetTop(downrightrect) + downrightrect.Height)
            {
                IsCheked_downright = true;
                pointMove.X = Canvas.GetLeft(downrightrect);
                pointMove.Y = Canvas.GetTop(downrightrect);
                deltaX = e.GetPosition(canvas).X - Canvas.GetLeft(downrightrect);
                deltaY = e.GetPosition(canvas).Y - Canvas.GetTop(downrightrect);
            }
        }
        private void Canvas_MouseLeftButtonUp_rect(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            IsCheked_top = false; IsCheked_down = false; IsCheked_right = false; IsCheked_left = false;

            if (IsCheked_top_1)
            {
                shape.Height = shape.Height - (Canvas.GetTop(topell) - pointMove.Y);
                Canvas.SetTop(shape, e.GetPosition(canvas).Y - deltaY + (topell.Height / 2));

                Canvas.SetTop(rightell, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                Canvas.SetTop(leftell, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);

                IsCheked_top_1 = false;
            }
            if (IsCheked_down_1)
            {
                shape.Height = shape.Height + (Canvas.GetTop(downell) - pointMove.Y);

                Canvas.SetTop(rightell, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                Canvas.SetTop(leftell, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);

                IsCheked_down_1 = false;
            }
            if (IsCheked_right_1)
            {
                shape.Width = shape.Width + (Canvas.GetLeft(rightell) - pointMove.X);

                Canvas.SetLeft(topell, Canvas.GetLeft(shape) + shape.Width / 2 - topell.Width / 2);
                Canvas.SetLeft(downell, Canvas.GetLeft(shape) + shape.Width / 2 - downell.Width / 2);

                IsCheked_right_1 = false;
            }
            if (IsCheked_left_1)
            {
                shape.Width = shape.Width - (Canvas.GetLeft(leftell) - pointMove.X);
                Canvas.SetLeft(shape, e.GetPosition(canvas).X - deltaX + (leftell.Width / 2));

                Canvas.SetLeft(topell, Canvas.GetLeft(shape) + shape.Width / 2 - topell.Width / 2);
                Canvas.SetLeft(downell, Canvas.GetLeft(shape) + shape.Width / 2 - downell.Width / 2);

                IsCheked_left_1 = false;
            }
            ////////////////////////////////////
            if (IsCheked_topleft_1)
            {
                //shape.Height = shape.Height - (Canvas.GetTop(topleftrect) - pointMove.Y);
                //Canvas.SetTop(shape, e.GetPosition(canvas).Y - deltaY + (topleftrect.Height / 2));

                //Canvas.SetTop(topell, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                //Canvas.SetTop(downell, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);
                //Canvas.SetTop(rightell, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                //Canvas.SetTop(leftell, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);
                //Canvas.SetTop(toprightrect, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                //Canvas.SetTop(downleftrect, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);

                //IsCheked_topleft_1 = false;
            }
            if (IsCheked_topright_1)
            {
                //shape.Height = shape.Height - (Canvas.GetTop(toprightrect) - pointMove.Y);
                //Canvas.SetTop(shape, e.GetPosition(canvas).Y - deltaY + (toprightrect.Height / 2));

                //Canvas.SetTop(topell, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                //Canvas.SetTop(downell, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);
                //Canvas.SetTop(rightell, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                //Canvas.SetTop(leftell, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);
                //Canvas.SetTop(topleftrect, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                //Canvas.SetTop(downrightrect, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);

                //IsCheked_topright_1 = false;
            }
            if (IsCheked_downleft_1)
            {
                //shape.Height = shape.Height - (Canvas.GetTop(downleftrect) - pointMove.Y);
                //Canvas.SetTop(shape, e.GetPosition(canvas).Y - deltaY + (downleftrect.Height / 2));

                //Canvas.SetTop(topell, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                //Canvas.SetTop(downell, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);
                //Canvas.SetTop(rightell, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                //Canvas.SetTop(leftell, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);
                //Canvas.SetTop(topleftrect, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                //Canvas.SetTop(downrightrect, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);

                //IsCheked_downleft_1 = false;
            }
            if (IsCheked_downright_1)
            {
                //shape.Height = shape.Height - (Canvas.GetTop(downrightrect) - pointMove.Y);
                //Canvas.SetTop(shape, e.GetPosition(canvas).Y - deltaY + (downrightrect.Height / 2));

                //Canvas.SetTop(topell, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                //Canvas.SetTop(downell, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);
                //Canvas.SetTop(rightell, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                //Canvas.SetTop(leftell, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);
                //Canvas.SetTop(toprightrect, Canvas.GetTop(shape) + shape.Height / 2 - rightell.Height / 2);
                //Canvas.SetTop(downleftrect, Canvas.GetTop(shape) + shape.Height / 2 - leftell.Height / 2);

                //IsCheked_downright_1 = false;
            }
        }
        private void Canvas_MouseMove_rect(object sender, MouseEventArgs e)
        {
            if (IsCheked_top)
            {
                Canvas.SetTop(topell, e.GetPosition(canvas).Y - deltaY);
                IsCheked_top_1 = true;
            }
            if (IsCheked_down)
            {
                Canvas.SetTop(downell, e.GetPosition(canvas).Y - deltaY);
                IsCheked_down_1 = true;
            }
            if (IsCheked_right)
            {
                Canvas.SetLeft(rightell, e.GetPosition(canvas).X - deltaX);
                IsCheked_right_1 = true;
            }
            if (IsCheked_left)
            {
                Canvas.SetLeft(leftell, e.GetPosition(canvas).X - deltaX);
                IsCheked_left_1 = true;
            }

            /////////////////////////////////////////////

            if (IsCheked_topleft)
            {
                Canvas.SetTop(topleftrect, e.GetPosition(canvas).Y - deltaY);
                Canvas.SetLeft(topleftrect, e.GetPosition(canvas).X - deltaX );
                IsCheked_topleft_1 = true;
            }
            if (IsCheked_topright)
            {
                Canvas.SetTop(toprightrect, e.GetPosition(canvas).Y - deltaY);
                Canvas.SetLeft(toprightrect, e.GetPosition(canvas).Y - deltaY);
                IsCheked_topright_1 = true;
            }
            if (IsCheked_downleft)
            {
                Canvas.SetTop(downleftrect, -(e.GetPosition(canvas).X - deltaX));
                Canvas.SetLeft(downleftrect, e.GetPosition(canvas).X - deltaX);
                IsCheked_downleft_1 = true;
            }
            if (IsCheked_downright)
            {
                Canvas.SetTop(downrightrect, e.GetPosition(canvas).Y - deltaY);
                Canvas.SetLeft(downrightrect, e.GetPosition(canvas).Y - deltaY);
                IsCheked_downright_1 = true;
            }
        }
    }
}
