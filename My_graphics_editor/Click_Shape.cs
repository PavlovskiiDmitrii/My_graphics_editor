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
        Additional_Shapes additionalShapes;
        Set_Item_Content set_item_content;
        public Shape last_local_shape;

        public Click_Shape(Get_Items_Form get_items_form)
        {
            set_item_content = new Set_Item_Content(get_items_form);
            additionalShapes = new Additional_Shapes(get_items_form.canvas);
        }
        public void click_in_shape(Shape shape)
        {
            shape.MouseLeftButtonDown += EllipseOnMouseLeftButtonDown;
            shape.MouseLeftButtonUp += EllipseOnMouseLeftButtonUp;
        }

        public void EllipseOnMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        { 
        }
        public void EllipseOnMouseLeftButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            Shape local_shape = (Shape)sender;
            if (_isAttached == false)
            {
                last_local_shape = local_shape;
                _isAttached = true;

                additionalShapes.In_Canvas_Add(local_shape);
                set_item_content.Set_Content(local_shape);
            }
            else
            {
                if (_isAttached == true && last_local_shape == local_shape)
                {
                    _isAttached = false;

                    additionalShapes.In_Canvas_Remove(local_shape);
                    set_item_content.Null_Content();
                }
                if (_isAttached == true && last_local_shape != local_shape)
                {
                    last_local_shape = local_shape;
                    _isAttached = true;

                    additionalShapes.In_Canvas_Remove(last_local_shape);
                    additionalShapes.In_Canvas_Add(local_shape);
                    set_item_content.Set_Content(local_shape);
                }
            }
        }
    }
}
