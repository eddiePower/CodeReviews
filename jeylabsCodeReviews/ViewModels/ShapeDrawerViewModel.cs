using System;
using System.Windows.Shapes;

namespace jeylabsCodeReviews.ViewModels
{
    public class ShapeDrawerViewModel : ObservableObject
    {
        private Ellipse circleDrawing;
        private Rectangle rectangleDrawing;
        private Polygon triangleDrawing;
        private Shape baseShape;
        

        public ShapeDrawerViewModel()
        {
            Console.WriteLine("Debug: in the ShapesDrawer View Model");
            rectangleDrawing = new Rectangle();
            circleDrawing = new Ellipse();
            triangleDrawing = new Polygon();
        }

        public Shape DrawShape
        {
            get { return baseShape; }
            set
            {
                if (Equals(baseShape, value)) return;
                baseShape = value;
            }
        }



    }
}