using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using NUnit.Framework;
using My_graphics_editor;

namespace My_graphics_editor_TEST
{
    [TestFixture]
    public class Tests
    {
        [STAThread]
        [Test]
        public void Appearance_SetAppearance_Ell_or_Rec()
        {
            Appearance appearance = new Appearance();
            Ellipse ell = new Ellipse();
            appearance.SetAppearance(ell);
            Assert.AreEqual(ell.Height, 50);
        }

        [STAThread]
        [Test]
        public void Appearance_SetAppearance_Name()
        {
            Appearance appearance = new Appearance();
            Ellipse ell = new Ellipse();
            Ellipse ell2 = new Ellipse();
            appearance.SetAppearance(ell);
            appearance.SetAppearance(ell2);
            Assert.AreEqual(ell2.Name, "Name_Ell_2");
        }

        [STAThread]
        [Test]
        public void Get_Items_Form_canvas()
        {
            Label l1 = new Label();
            Label l2 = new Label();
            Label l3 = new Label();
            Canvas canvas = new Canvas();
            Get_Items_Form get_items_form = new Get_Items_Form(canvas,l1,l2,l3);
            Assert.AreEqual(get_items_form.canvas, canvas);
        }

        [STAThread]
        [Test]
        public void Get_Items_Form_labelName()
        {
            Label lName = new Label();
            Label lSize = new Label();
            Label lColor = new Label();
            Canvas canvas = new Canvas();
            Get_Items_Form get_items_form = new Get_Items_Form(canvas, lName, lSize, lColor);
            Assert.AreEqual(get_items_form.labelName, lName);
        }

        [STAThread]
        [Test]
        public void Get_Items_Form_labelColor()
        {
            Label lName = new Label();
            Label lSize = new Label();
            Label lColor = new Label();
            Canvas canvas = new Canvas();
            Get_Items_Form get_items_form = new Get_Items_Form(canvas, lName, lSize, lColor);
            Assert.AreEqual(get_items_form.labelColor, lColor);
        }

        [STAThread]
        [Test]
        public void Get_Items_Form_labelSize()
        {
            Label lName = new Label();
            Label lSize = new Label();
            Label lColor = new Label();
            Canvas canvas = new Canvas();
            Get_Items_Form get_items_form = new Get_Items_Form(canvas, lName, lSize, lColor);
            Assert.AreEqual(get_items_form.labelSize, lSize);
        }

        [STAThread]
        [Test]
        public void Get_Shape_Ell()
        {
            Get_Shape get_shape = new Get_Shape();
            Ellipse ell = new Ellipse();
            Shape shape =  get_shape.Type("Ellipse");
            Assert.AreEqual(shape.GetType(),ell.GetType());
        }

        [STAThread]
        [Test]
        public void Get_Shape_Rec()
        {
            Get_Shape get_shape = new Get_Shape();
            Rectangle rec = new Rectangle();
            Shape shape = get_shape.Type("Rectangle");
            Assert.AreEqual(shape.GetType(), rec.GetType());
        }

        [STAThread]
        [Test]
        public void Get_Shape_Pol()
        {
            Get_Shape get_shape = new Get_Shape();
            Polygon pol = new Polygon();
            Shape shape = get_shape.Type("Treangle");
            Assert.AreEqual(shape.GetType(), pol.GetType());
        }

        [STAThread]
        [Test]
        public void List_Shapes_AddShape_Count()
        {
            List_Shapes list_shapes = new List_Shapes();
            Ellipse shape = new Ellipse();
            list_shapes.AddShape(shape);
            Assert.AreEqual(list_shapes.Get_count_list(),1);
        }

        [STAThread]
        [Test]
        public void List_Shapes_Remove_Count()
        {
            List_Shapes list_shapes = new List_Shapes();
            Ellipse shape1 = new Ellipse();
            Ellipse shape2 = new Ellipse();
            list_shapes.AddShape(shape1);
            list_shapes.AddShape(shape2);
            list_shapes.DeleteShape(shape1);
            Assert.AreEqual(list_shapes.Get_count_list(), 1);
        }

        [STAThread]
        [Test]
        public void List_Shapes_Get_shape()
        {
            List_Shapes list_shapes = new List_Shapes();
            Ellipse shape1 = new Ellipse();
            Ellipse shape2 = new Ellipse();
            list_shapes.AddShape(shape1);
            list_shapes.AddShape(shape2);
            Assert.AreEqual(list_shapes.Get_shape(2), shape2);
        }

       
    }
}
