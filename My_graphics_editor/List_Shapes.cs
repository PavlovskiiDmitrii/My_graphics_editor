using System.Windows;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_graphics_editor
{
    class List_Shapes
    {
        private List<Shape> shepes_list = new List<Shape>();

        public void AddShape(Shape shape)
        {
            shepes_list.Add(shape);
        }
        public void DeleteVisual(Shape shape)
        {
            shepes_list.Remove(shape);
        }
    }
}
