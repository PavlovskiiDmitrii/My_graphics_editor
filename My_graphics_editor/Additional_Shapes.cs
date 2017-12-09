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
        Set_Item_Content set_item_content;

        Ellipse topell = new Ellipse();
        Ellipse downell = new Ellipse();
        Ellipse leftell = new Ellipse();
        Ellipse rightell = new Ellipse();
        Rectangle topleftrect = new Rectangle();
        Rectangle toprightrect = new Rectangle();
        Rectangle downleftrect = new Rectangle();
        Rectangle downrightrect = new Rectangle();

        Xceed.Wpf.Toolkit.ColorPicker colorPicker;

        Resize_Ell resize_ell;
        Resize_Rec resize_rec;

        public Additional_Shapes(Canvas canvas, Xceed.Wpf.Toolkit.ColorPicker colorPicker, Set_Item_Content set_item_content)
        {
            this.colorPicker = colorPicker;
            this.canvas = canvas;
            this.set_item_content = set_item_content;
        }

        public void refresh(Shape shape)
        {
            if(shape.GetType() == typeof(Ellipse) )
            {
                resize_ell.Refresh_additionaal_Shapes(shape);
            }
            if(shape.GetType() == typeof(Rectangle))
            {
                resize_rec.Refresh_additionaal_Shapes(shape);
            }
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

                resize_ell = new Resize_Ell(shape, canvas, colorPicker, topell, downell, leftell, rightell);
            }
            if (shape.GetType() == typeof(Rectangle))
            {
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

                resize_rec = new Resize_Rec(shape, canvas, colorPicker, topleftrect, toprightrect, downleftrect, downrightrect);
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

                    if (resize_ell != null)
                    {
                        resize_ell.Remove_Mouse_Event();
                    }
                }
                if (shape.GetType() == typeof(Rectangle))
                {
                    canvas.Children.Remove(topleftrect);
                    canvas.Children.Remove(toprightrect);
                    canvas.Children.Remove(downleftrect);
                    canvas.Children.Remove(downrightrect);

                    if (resize_rec != null)
                    {
                        resize_rec.Remove_Mouse_Event();
                    }
               }
            
        }

        public void Appearance_Ellepse(Shape topell)
        {
            Canvas.SetZIndex(topell, 1000);
            topell.Width = 13.5;
            topell.Height = 13.5;
            topell.Fill = Brushes.White;
            topell.Stroke = Brushes.Black;
            topell.StrokeThickness = 1.5;
            canvas.Children.Add(topell);
        }
        public void Appearance_Rectangle(Shape topell)
        {
            Canvas.SetZIndex(topell, 1000);
            topell.Width = 14;
            topell.Height = 14;
            topell.Fill = Brushes.White;
            topell.Stroke = Brushes.Black;
            topell.StrokeThickness =1.5;
            canvas.Children.Add(topell);
        }
    }
}
