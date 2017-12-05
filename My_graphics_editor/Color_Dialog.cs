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
    public class Color_Dialog
    {
        public Xceed.Wpf.Toolkit.ColorPicker colorPicker;
        Shape shape;
        Brush br;
    
        public Color_Dialog(Xceed.Wpf.Toolkit.ColorPicker colorPicker)
        {
            this.colorPicker = colorPicker;
            colorPicker.SelectedColorChanged += ColorPicker_SelectedColorChanged;
        }


        public void Color_Changed(Shape shape)
        {
            this.shape = shape;
            
        }
        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
          //  MessageBox.Show(Convert.ToString(colorPicker.SelectedColor));
            br = new SolidColorBrush((Color)colorPicker.SelectedColor);
            shape.Fill = br;
        }
        
    }
}
