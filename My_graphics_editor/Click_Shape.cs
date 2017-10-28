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
        private FrameworkElement _attachedElement;
        private Point _clickPoint;
        MainWindow m = new MainWindow();
        Shape shape;

        public Click_Shape(Shape shape)
        {
            shape.MouseLeftButtonDown += EllipseOnMouseLeftButtonDown;
            shape.MouseLeftButtonUp += EllipseOnMouseLeftButtonUp;
        }

        public void MainCanvasOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
           
        }

        public void EllipseOnMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
           // _isAttached = false;
        }

        public void EllipseOnMouseLeftButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            shape = sender as Shape;
            MessageBox.Show(shape.Name + "_" + shape.Width);
           // _clickPoint = mouseButtonEventArgs.GetPosition(sender as FrameworkElement);
           // _attachedElement = sender as FrameworkElement;

           // _isAttached = true;
        }
    }
}
