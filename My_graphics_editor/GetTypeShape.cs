using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace My_graphics_editor
{
    public class GetTypeShape
    {
        public Shape Type(string type)
        {
            if(type == "Ellipse")
            {
                Shape shape = new Ellipse();
                return shape;
            }
            else
            {
                if (type == "Rectaangle")
                {
                    Shape shape = new Rectangle();
                    return shape;
                }
                else
                {
                    if (type == "Treangle")
                    {
                        Shape shape = new Polygon();
                        return shape;
                    }
                }
            }
            return null;
        }
    }
}
