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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Get_Items_Form get_items_form;
        New_Figure new_figure;
        Click_Shape click_shape;

        public MainWindow()
        {
            InitializeComponent();
            get_items_form = new Get_Items_Form(Canvas1, LbName, LbSize, LbColor);
            new_figure = new New_Figure(get_items_form);
            click_shape = new Click_Shape(get_items_form);
        }
        List_Shapes list_shapes = new List_Shapes();
        Save_In_File save_in_file = new Save_In_File();
        Shape shape;
        
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            shape = new_figure.Drawing(Cb1.Text);
            Canvas1.Children.Add(shape);
            list_shapes.AddShape(shape);
            click_shape.click_in_shape(shape);
        }

        private void ButtonSaveInFile_Click(object sender, RoutedEventArgs e)
        {
            save_in_file.save(list_shapes);
        }
    }
}