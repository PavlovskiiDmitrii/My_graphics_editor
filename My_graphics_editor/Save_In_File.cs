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
    public class Save_In_File
    {
        public void save(List_Shapes list_shapes)
        {
            string finishString = null;
            for (int i = 0; i < list_shapes.Get_count_list(); i++)
            {
                finishString = finishString + Convert.ToString("Type: " + list_shapes.Get_shape(i).GetType() + " name: " + list_shapes.Get_shape(i).Name + " Width: " + list_shapes.Get_shape(i).Width) + "\n";
            }
            MessageBox.Show(finishString);
            finishString = null;
        }
    }
}
