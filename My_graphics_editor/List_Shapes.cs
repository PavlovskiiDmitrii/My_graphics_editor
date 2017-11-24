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
    public  class List_Shapes
    {
        public List<Shape> shapes_list = new List<Shape>();

        public void AddShape(Shape shape)
        {
            shapes_list.Add(shape);
        }
        public void DeleteVisual(Shape shape)
        {
            shapes_list.Remove(shape);
        }
        public Shape Get_shape(int i)
        {
            return shapes_list[i];
        }
        public int Get_count_list()
        {
            return shapes_list.Count;
        }
    }
}
