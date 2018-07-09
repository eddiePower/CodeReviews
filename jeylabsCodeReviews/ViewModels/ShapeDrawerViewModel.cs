using System;
using System.Windows.Shapes;
using jeylabsCodeReviews.uttils;

namespace jeylabsCodeReviews.ViewModels
{
    public class ShapeDrawerViewModel : ObservableObject
    {
        private Ellipse circleDrawing;
        private Rectangle rectangleDrawing;
        private Polygon triangleDrawing;
        private Shape baseShape;
        private ShapeDrawerPageViewModel shapeDraweringPageViewModel;


        public ShapeDrawerViewModel(ShapeDrawerPageViewModel mainPageViewModel)
        {
            Console.WriteLine("Debug: in the ShapesDrawer View Model");
            shapeDraweringPageViewModel = mainPageViewModel;
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
                shapeDraweringPageViewModel.ShapeCreatedReadyToPaint?.Invoke(baseShape);
                OnPropertyChanged(nameof(DrawShape));
            }
        }



    }
}