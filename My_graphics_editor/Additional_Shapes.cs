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
    public class Additional_Shapes
    {
        Canvas canvas;

        Ellipse topell = new Ellipse();
        Ellipse downell = new Ellipse();
        Ellipse leftell = new Ellipse();
        Ellipse rightell = new Ellipse();
        Rectangle topleftrect = new Rectangle();
        Rectangle toprightrect = new Rectangle();
        Rectangle downleftrect = new Rectangle();
        Rectangle downrightrect = new Rectangle();

        Resize_Shape resize_shape;

        public Additional_Shapes(Canvas canvas)
        {
            this.canvas = canvas;
           
        }
        public void In_Canvas_Add(Shape shape)
        {
            if (shape.GetType() == typeof(Ellipse))
            {
                Appearance_Ellepse(topell);
                Canvas.SetTop(topell, Canvas.GetTop(shape) - (topell.Height) / 2);
                Canvas.SetLeft(topell, Canvas.GetLeft(shape) + (shape.Width / 2) - (topell.Width) / 2);
                Appearance_Ellepse(downell);
                Canvas.SetTop(downell, Canvas.GetTop(shape) + ((shape.Height)) - (downell.Height / 2));
                Canvas.SetLeft(downell, Canvas.GetLeft(shape) + (shape.Width / 2) - (downell.Width) / 2);
                Appearance_Ellepse(leftell);
                Canvas.SetTop(leftell, Canvas.GetTop(shape) + ((shape.Height) / 2) - (leftell.Height / 2));
                Canvas.SetLeft(leftell, Canvas.GetLeft(shape) - (leftell.Width) / 2);
                Appearance_Ellepse(rightell);
                Canvas.SetTop(rightell, Canvas.GetTop(shape) + ((shape.Height) / 2) - (rightell.Height / 2));
                Canvas.SetLeft(rightell, Canvas.GetLeft(shape) + (shape.Width) - (rightell.Width) / 2);

               resize_shape = new Resize_Shape(shape, canvas,topell, downell,leftell,rightell);
            }
            if (shape.GetType() == typeof(Rectangle))
            {
                Appearance_Ellepse(topell);
                Canvas.SetTop(topell, Canvas.GetTop(shape) - (topell.Height) / 2);
                Canvas.SetLeft(topell, Canvas.GetLeft(shape) + (shape.Width / 2) - (topell.Width) / 2);
                Appearance_Ellepse(downell);
                Canvas.SetTop(downell, Canvas.GetTop(shape) + ((shape.Height)) - (downell.Height / 2));
                Canvas.SetLeft(downell, Canvas.GetLeft(shape) + (shape.Width / 2) - (downell.Width) / 2);
                Appearance_Ellepse(leftell);
                Canvas.SetTop(leftell, Canvas.GetTop(shape) + ((shape.Height) / 2) - (leftell.Height / 2));
                Canvas.SetLeft(leftell, Canvas.GetLeft(shape) - (leftell.Width) / 2);
                Appearance_Ellepse(rightell);
                Canvas.SetTop(rightell, Canvas.GetTop(shape) + ((shape.Height) / 2) - (rightell.Height / 2));
                Canvas.SetLeft(rightell, Canvas.GetLeft(shape) + (shape.Width) - (rightell.Width) / 2);
                Appearance_Rectangle(topleftrect);
                Canvas.SetTop(topleftrect, Canvas.GetTop(shape) - (topleftrect.Height) / 2);
                Canvas.SetLeft(topleftrect, Canvas.GetLeft(shape) - (topleftrect.Width) / 2);
                Appearance_Rectangle(toprightrect);
                Canvas.SetTop(toprightrect, Canvas.GetTop(shape) - (toprightrect.Height) / 2);
                Canvas.SetLeft(toprightrect, Canvas.GetLeft(shape) + (shape.Width) - (toprightrect.Width) / 2);
                Appearance_Rectangle(downleftrect);
                Canvas.SetTop(downleftrect, Canvas.GetTop(shape) + (shape.Height) - (downleftrect.Height) / 2);
                Canvas.SetLeft(downleftrect, Canvas.GetLeft(shape) - (downleftrect.Width) / 2);
                Appearance_Rectangle(downrightrect);
                Canvas.SetTop(downrightrect, Canvas.GetTop(shape) + (shape.Height) - (downrightrect.Height) / 2);
                Canvas.SetLeft(downrightrect, Canvas.GetLeft(shape) + (shape.Width) - (downrightrect.Width) / 2);

               resize_shape = new Resize_Shape(shape, canvas, topell, downell, leftell, rightell, topleftrect,toprightrect,downleftrect,downrightrect);
            }
        }
        public void In_Canvas_Remove(Shape shape)
        {
            if (shape.GetType() == typeof(Ellipse))
            {
                canvas.Children.Remove(topell);
                canvas.Children.Remove(downell);
                canvas.Children.Remove(leftell);
                canvas.Children.Remove(rightell);
                resize_shape.Remove_Mouse_Event();
            }
            if (shape.GetType() == typeof(Rectangle))
            {
                canvas.Children.Remove(topell);
                canvas.Children.Remove(downell);
                canvas.Children.Remove(leftell);
                canvas.Children.Remove(rightell);
                canvas.Children.Remove(topleftrect);
                canvas.Children.Remove(toprightrect);
                canvas.Children.Remove(downleftrect);
                canvas.Children.Remove(downrightrect);
                resize_shape.Remove_Mouse_Event();
            }
        }

        public void Appearance_Ellepse(Shape topell)
        {
            topell.Width = 18;
            topell.Height = 18;
            topell.Fill = Brushes.White;
            topell.Stroke = Brushes.Black;
            topell.StrokeThickness = 2;
            canvas.Children.Add(topell);
        }
        public void Appearance_Rectangle(Shape topell)
        {
            topell.Width = 20;
            topell.Height = 20;
            topell.Fill = Brushes.White;
            topell.Stroke = Brushes.Black;
            topell.StrokeThickness = 2;
            canvas.Children.Add(topell);
        }

    }
}
