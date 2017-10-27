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
    class New_Figure
    {
        Random random = new Random();
        Appearance appearance = new Appearance();
        private DrawingVisual selectedVisual;

        public enum TypeoShapes
        {
            Treangle,Ellipse,Rectaangle
        }
        public void Set_Canvas(Canvas canvas)
        {
            appearance.Set_Canvas(canvas);
        }

        public Shape Drawing(TypeoShapes Id)
        {
            
            if(Id == TypeoShapes.Ellipse)
            {
                Shape shape = new Ellipse();
                appearance.Modif_Shape_Group1(shape);
                return shape;
            }
            if(Id == TypeoShapes.Rectaangle)
            {
                Shape shape = new Rectangle();
                appearance.Modif_Shape_Group1(shape);
                return shape;
            }
            if(Id == TypeoShapes.Treangle)
            {
                Polygon shape = new Polygon();
                appearance.Modif_Shape_Group2(shape);
                return shape;
            }
            return null;
        }
    }
}
