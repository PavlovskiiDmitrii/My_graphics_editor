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
        Shape shape;
        Canvas canvas;
        AdditionalShapes additionalShapes;

        public Click_Shape(Shape shape,Canvas canvas)
        {
            this.canvas = canvas;
            shape.MouseLeftButtonDown += EllipseOnMouseLeftButtonDown;
            shape.MouseLeftButtonUp += EllipseOnMouseLeftButtonUp;
        }

        public void EllipseOnMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            shape = sender as Shape;
            MessageBox.Show(Convert.ToString(shape.GetType()));
        }

        public void EllipseOnMouseLeftButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
           
            shape = sender as Shape;
            if(_isAttached == false)
            {
                additionalShapes = new AdditionalShapes(shape, canvas);
                _isAttached = true;
            }
            else
            {
                Application.Current.MainWindow.FindName("LbName");
                _isAttached = false;
            }
          
           // m.LbName.Content = m.LbName.Content + shape.Name;
           //MessageBox.Show(Convert.ToString(shape.GetType()));
        }
    }
}
