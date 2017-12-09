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
    class Click_Shape
    {
        private bool _isAttached = false;
        private bool _in_shape = false;
        private bool _in_shape_right = false;
        Additional_Shapes additionalShapes;
        Set_Item_Content set_item_content;
        Shape local_shape;

        Point pointMove;

        double deltaX = 0;
        double deltaY = 0;

        int Zindex = 0;
        public Shape last_local_shape;
        Color_Dialog color_diolog;
        Get_Items_Form get_items_form = new Get_Items_Form();

        public Click_Shape(Get_Items_Form get_items_form)
        {
            this.get_items_form = get_items_form;
            color_diolog = new Color_Dialog(get_items_form.colorPicker);
            set_item_content = new Set_Item_Content(get_items_form);
            additionalShapes = new Additional_Shapes(get_items_form.canvas, color_diolog.colorPicker, set_item_content);
        }
        public void click_in_shape(Shape shape)
        {
            shape.MouseLeftButtonDown += EllipseOnMouseLeftButtonDown;
            shape.MouseLeftButtonUp += EllipseOnMouseLeftButtonUp;
            shape.MouseMove += Shape_MouseMove;
            shape.MouseRightButtonDown += Shape_MouseRightButtonDown;
            shape.MouseRightButtonUp += Shape_MouseRightButtonUp;
        }

        private void Shape_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            _in_shape_right = false;
            Mouse.Capture(null);
        }

        private void Shape_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            local_shape = (Shape)sender;

            if (_in_shape && local_shape == last_local_shape)
            {
                _in_shape_right = true;
                Mouse.Capture(local_shape);

                deltaX = e.GetPosition(get_items_form.canvas).X - Canvas.GetLeft(local_shape);
                deltaY = e.GetPosition(get_items_form.canvas).Y - Canvas.GetTop(local_shape);

                pointMove.X = Canvas.GetLeft(local_shape);
                pointMove.Y = Canvas.GetTop(local_shape);
            }
        }

        public void EllipseOnMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {

        }
        public void EllipseOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            local_shape = (Shape)sender;

            Canvas.SetZIndex(local_shape,Zindex++);

            if (_isAttached == false)
            {
                color_diolog.Color_Changed(local_shape);
                last_local_shape = local_shape;
                _isAttached = true;
                _in_shape = true;
                additionalShapes.In_Canvas_Add(local_shape);
                set_item_content.Set_Content(local_shape);
                get_items_form.colorPicker.SelectedColor = ((System.Windows.Media.SolidColorBrush)(local_shape.Fill)).Color;
            }
            else
            {
                if (_isAttached == true && last_local_shape == local_shape)
                {
                    _isAttached = false;
                    _in_shape = false;
                    additionalShapes.In_Canvas_Remove(local_shape);
                    set_item_content.Null_Content();
                }
                if (_isAttached == true && last_local_shape != local_shape)
                {
                    color_diolog.Color_Changed(local_shape);
                    last_local_shape = local_shape;
                    _isAttached = true;
                    _in_shape = true;
                    additionalShapes.In_Canvas_Remove(last_local_shape);
                    additionalShapes.In_Canvas_Add(local_shape);
                    set_item_content.Set_Content(local_shape);

                    get_items_form.colorPicker.SelectedColor = ((System.Windows.Media.SolidColorBrush)(local_shape.Fill)).Color;
                }
            }
        }
        private void Shape_MouseMove(object sender, MouseEventArgs e)
        {
            if (_in_shape_right)
            {
                Canvas.SetTop(local_shape, e.GetPosition(get_items_form.canvas).Y - deltaY);
                Canvas.SetLeft(local_shape, e.GetPosition(get_items_form.canvas).X - deltaX);
                additionalShapes.refresh(local_shape);
            }
        }
    }
}
