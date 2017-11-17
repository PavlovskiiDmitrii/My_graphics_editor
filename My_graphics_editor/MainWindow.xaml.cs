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
        public MainWindow()
        {
            InitializeComponent();
        }
        New_Figure new_figure = new New_Figure();

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            new_figure.Set_Canvas(Canvas1);
            if (Cb1.SelectedIndex == 0)
            {
                Canvas1.Children.Add(new_figure.Drawing(New_Figure.TypeoShapes.Ellipse));
            }
            if (Cb1.SelectedIndex == 1)
            {
                Canvas1.Children.Add(new_figure.Drawing(New_Figure.TypeoShapes.Rectaangle));
            }
            if (Cb1.SelectedIndex == 2)
            {
                Canvas1.Children.Add(new_figure.Drawing(New_Figure.TypeoShapes.Treangle));
            }
        }
    }
}