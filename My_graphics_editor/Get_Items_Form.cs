
using System.Windows.Shapes;
using System.Windows.Controls;

namespace My_graphics_editor
{
    public class Get_Items_Form
    {
        public Canvas canvas { get; set; }
        public Label labelName { get; set; }
        public Label labelSize { get; set; }
        public Label labelColor { get; set; }
        public Xceed.Wpf.Toolkit.ColorPicker colorPicker { get; set; }

        public Get_Items_Form()
        { }

        public Get_Items_Form(Canvas canvas, Xceed.Wpf.Toolkit.ColorPicker colorPicker, Label labelName, Label labelSize, Label labelColor)
        {
            this.labelName = labelName;
            this.labelSize = labelSize;
            this.labelColor = labelColor;
            this.canvas = canvas;
            this.colorPicker = colorPicker;
        }
    }
}
