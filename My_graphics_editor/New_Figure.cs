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
    public class New_Figure
    {
        Appearance appearance = new Appearance();
        GetTypeShape getShapeType = new GetTypeShape();
        Get_Items_Form get_items_form;

        public New_Figure(Get_Items_Form get_items_form)
        {
            this.get_items_form = get_items_form;
        }

        public Shape Drawing(string type)
        {
           Shape shape = getShapeType.Type(type);
           appearance.Set_Canvas (get_items_form.canvas);
           appearance.Modif_Shape_Group1(shape);
          // Click_Shape click_shape = new Click_Shape(shape,get_items_form);
           return shape;
        }
    }
}
