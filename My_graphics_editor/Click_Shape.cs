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
        Label labelName;
        Label labelSize;
        Label labelColor;

        AdditionalShapes additionalShapes;
        List<AdditionalShapes> addList = new List<AdditionalShapes>();

        public Click_Shape(Get_Items_Form get_items_form)
        {
            this.canvas = get_items_form.canvas;
            this.labelName = get_items_form.labelName;
            this.labelSize = get_items_form.labelSize;
            this.labelColor = get_items_form.labelColor;
        }
        public void click_in_shape(Shape shape)
        {
            this.shape = shape;
            shape.MouseLeftButtonDown += EllipseOnMouseLeftButtonDown;
            shape.MouseLeftButtonUp += EllipseOnMouseLeftButtonUp;
        }

        public void EllipseOnMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            // MessageBox.Show(Convert.ToString(shape.GetType()));
            //labelName.Content = null;
            //labelSize.Content = null;
           //labelColor.Content = null;
        }

        public void EllipseOnMouseLeftButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            additionalShapes = new AdditionalShapes(shape, canvas);
            if (_isAttached == false)
            {
                addList.Add(additionalShapes);
                _isAttached = true;
                labelName.Content = shape.Name;
                labelSize.Content = "He: " + shape.Height +" Wi: " + shape.Width;
                labelColor.Content = shape.Fill;
            }
            else
            {
                _isAttached = false;
                labelName.Content = null;
                labelSize.Content = null;
                labelColor.Content = null;
            }
           
        }
    }
}
