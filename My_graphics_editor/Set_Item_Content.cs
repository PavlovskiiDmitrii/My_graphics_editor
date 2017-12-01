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
    public class Set_Item_Content
    {
        Get_Items_Form get_items_form;

        public Set_Item_Content(Get_Items_Form get_items_form)
        {
           this.get_items_form = get_items_form;
        }

        public void Set_Content(Shape shape)
        {
            get_items_form.labelName.Content = shape.Name;
            get_items_form.labelSize.Content = "He: " + shape.Height + " Wi: " + shape.Width;
            get_items_form.labelColor.Content = shape.Fill;
        }
        public void Null_Content()
        {
            get_items_form.labelName.Content = "";
            get_items_form.labelSize.Content = "";
            get_items_form.labelColor.Content = "";
        }

    }
}
