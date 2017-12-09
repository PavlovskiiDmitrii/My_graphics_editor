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

        Rectangle topleftrect = new Rectangle();
        Rectangle toprightrect = new Rectangle();
        Rectangle downleftrect = new Rectangle();
        Rectangle downrightrect = new Rectangle();

        Xceed.Wpf.Toolkit.ColorPicker colorPicker;

        Point pointMove;

        bool IsCheked_topleft = false;
        bool IsCheked_topright = false;
        bool IsCheked_downleft = false;
        bool IsCheked_downright = false;

        double deltaX = 0;
        double deltaY = 0;

        public Resize_Rec(Shape shape, Canvas canvas, Xceed.Wpf.Toolkit.ColorPicker colorPicker, Rectangle topleftrect, Rectangle toprightrect, Rectangle downleftrect, Rectangle downrightrect)
        {
            this.colorPicker = colorPicker;
            this.shape = shape;
            this.canvas = canvas;
            canvas.MouseLeftButtonDown += Canvas_MouseLeftButtonDown_rect;
            canvas.MouseLeftButtonUp += Canvas_MouseLeftButtonUp_rect;
            canvas.MouseMove += Canvas_MouseMove_rect;
            this.topleftrect = topleftrect;
            this.toprightrect = toprightrect;
            this.downleftrect = downleftrect;
            this.downrightrect = downrightrect;
        }
        public void Refresh_additionaal_Shapes(Shape shape)
        {

            Canvas.SetTop(topleftrect, Canvas.GetTop(shape) - topleftrect.Height / 2);
            Canvas.SetLeft(topleftrect, Canvas.GetLeft(shape)- topleftrect.Width / 2);

            Canvas.SetTop(toprightrect, Canvas.GetTop(shape) - toprightrect.Height / 2);
            Canvas.SetLeft(toprightrect, Canvas.GetLeft(shape)+ shape.Width - topleftrect.Width / 2);

            Canvas.SetTop(downleftrect, Canvas.GetTop(shape) + shape.Height  - downleftrect.Height / 2);
            Canvas.SetLeft(downleftrect, Canvas.GetLeft(shape) - downleftrect.Width / 2);

            Canvas.SetTop(downrightrect, Canvas.GetTop(shape) + shape.Height  - downrightrect.Height / 2);
            Canvas.SetLeft(downrightrect, Canvas.GetLeft(shape)+shape.Width - downrightrect.Height / 2);
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
            IsCheked_topleft = false; IsCheked_topright = false; IsCheked_downright = false; IsCheked_downleft = false;
        }

        private void Canvas_MouseMove_rect(object sender, MouseEventArgs e)
        {
            if (IsCheked_topleft)
            {
                Canvas.SetTop(topleftrect, e.GetPosition(canvas).Y - deltaY);
                Canvas.SetLeft(topleftrect, e.GetPosition(canvas).X - deltaX);

                shape.Height = shape.Height + pointMove.Y - Canvas.GetTop(topleftrect);
                shape.Width = shape.Width + pointMove.X - Canvas.GetLeft(topleftrect);
                pointMove.Y = Canvas.GetTop(topleftrect);
                pointMove.X = Canvas.GetLeft(topleftrect);


                Canvas.SetTop(shape, e.GetPosition(canvas).Y - deltaY + (topleftrect.Height / 2));
                Canvas.SetLeft(shape, e.GetPosition(canvas).X - deltaX + (topleftrect.Width / 2));

                Canvas.SetTop(toprightrect, Canvas.GetTop(shape) - toprightrect.Height / 2); ;

                Canvas.SetLeft(downleftrect, Canvas.GetLeft(shape) - downleftrect.Width / 2);

            }
            if (IsCheked_topright)
            {
                Canvas.SetTop(toprightrect, e.GetPosition(canvas).Y - deltaY);
                Canvas.SetLeft(toprightrect, e.GetPosition(canvas).X - deltaX);

                shape.Height = shape.Height + pointMove.Y - Canvas.GetTop(toprightrect);
                shape.Width = shape.Width - (pointMove.X - Canvas.GetLeft(toprightrect));
                pointMove.Y = Canvas.GetTop(toprightrect);
                pointMove.X = Canvas.GetLeft(toprightrect);


                Canvas.SetTop(shape, e.GetPosition(canvas).Y - deltaY + (topleftrect.Height / 2));

                Canvas.SetTop(topleftrect, Canvas.GetTop(shape) - topleftrect.Height / 2);

                Canvas.SetLeft(downrightrect, Canvas.GetLeft(shape) + shape.Width - downleftrect.Width / 2);
            }
            if (IsCheked_downleft)
            {
                Canvas.SetTop(downleftrect, e.GetPosition(canvas).Y - deltaY);
                Canvas.SetLeft(downleftrect, e.GetPosition(canvas).X - deltaX);
                shape.Height = shape.Height - (pointMove.Y - Canvas.GetTop(downleftrect));
                shape.Width = shape.Width + pointMove.X - Canvas.GetLeft(downleftrect);
                pointMove.Y = Canvas.GetTop(downleftrect);
                pointMove.X = Canvas.GetLeft(downleftrect);

                Canvas.SetLeft(shape, e.GetPosition(canvas).X - deltaX + (topleftrect.Width / 2));

                Canvas.SetLeft(topleftrect, Canvas.GetLeft(shape) - topleftrect.Height / 2);
                Canvas.SetTop(downrightrect, Canvas.GetTop(shape) + shape.Height - downleftrect.Width / 2);

            }
            if (IsCheked_downright)
            {
                Canvas.SetTop(downrightrect, e.GetPosition(canvas).Y - deltaY);
                Canvas.SetLeft(downrightrect, e.GetPosition(canvas).X - deltaX);

                shape.Height = shape.Height - (pointMove.Y - Canvas.GetTop(downrightrect));
                shape.Width = shape.Width - (pointMove.X - Canvas.GetLeft(downrightrect));
                pointMove.Y = Canvas.GetTop(downrightrect);
                pointMove.X = Canvas.GetLeft(downrightrect);

                Canvas.SetLeft(toprightrect, Canvas.GetLeft(shape) + shape.Width - topleftrect.Height / 2);
                Canvas.SetTop(downleftrect, Canvas.GetTop(shape) + shape.Height - downleftrect.Width / 2);
            }
        }
    }
}
