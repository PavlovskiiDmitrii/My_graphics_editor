using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace My_graphics_editor
{
    class List_Shapes: Panel
    {

        // Коллекция уже нарисованных квадратов.
        private List<Visual> visuals = new List<Visual>();

        // Панель будет использовать этот метод для доступа к каждому элементу, который надо визуализировать.
        protected override Visual GetVisualChild(int index)
        {
            return visuals[index];
        }

        // Получение общего количества элементов для визуализации.
        protected override int VisualChildrenCount
        {
            get
            {
                return visuals.Count;
            }
        }

        public void AddVisual(Visual visual)
        {
            visuals.Add(visual);

            // Эти методы нужны для того, что бы корректно работали функции  взаимодействия элементов,
            // например, такие как проверка попадания курсора в элемент.
            base.AddVisualChild(visual);
            base.AddLogicalChild(visual);
        }

        public void DeleteVisual(Visual visual)
        {
            visuals.Remove(visual);
            base.RemoveVisualChild(visual);
            base.RemoveLogicalChild(visual);
        }

        // Метод для проверки попадания.
        public DrawingVisual GetVisual(Point point)
        {
            HitTestResult hitResult = VisualTreeHelper.HitTest(this, point);
            return hitResult.VisualHit as DrawingVisual;
        }
    }
}
