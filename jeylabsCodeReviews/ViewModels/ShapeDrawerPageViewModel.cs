using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using jeylabsCodeReviews.uttils;

namespace jeylabsCodeReviews.ViewModels
{
    public class ShapeDrawerPageViewModel : ObservableObject, IDisposable
    {
        private TextInputViewModel txtInputViewModel;
        private ShapeDrawerViewModel shapesDrawerViewModel;
        private string textIn;
        public Action<Shape> ShapeCreatedReadyToPaint;

        public ShapeDrawerPageViewModel()
        {
            textIn = "";            
            ShapeCreatedReadyToPaint += DrawShapeToScreen;

            shapesDrawerViewModel = new ShapeDrawerViewModel(this);
            txtInputViewModel = new TextInputViewModel(shapesDrawerViewModel);
        }

        private void DrawShapeToScreen(Shape obj)
        {
            switch (obj.Name)
            {
                //ToDo:  Replace Colours with variables retrieved from 
                // ToDo: the string sort / processing.
                case "rectangle" when obj is Rectangle rectangle:
                    rectangle.Stroke = new SolidColorBrush(Colors.Black);
                    rectangle.Fill = new SolidColorBrush(Colors.AliceBlue);

                    DrawShape = rectangle;
                    break;
                case "circle" when obj is Ellipse ellipse:
                    ellipse.Stroke = new SolidColorBrush(Colors.Black);
                    ellipse.Fill = new SolidColorBrush(Colors.AliceBlue);

                    DrawShape = ellipse;
                    break;
                case "triangle" when obj is Polygon polygon:
                    polygon.Points = new PointCollection(new[] {new Point(0, 40), new Point(40, 0), new Point(40,90)});
                    polygon.Stroke = new SolidColorBrush(Colors.Black);
                    polygon.Fill = new SolidColorBrush(Colors.AliceBlue);

                    DrawShape = polygon;
                    break;
                case "oval" when obj is Ellipse oval:
                    oval.Stroke = new SolidColorBrush(Colors.Black);
                    oval.Fill = new SolidColorBrush(Colors.AliceBlue);

                    DrawShape = oval;
                    break;
            }
        }

        public Shape ShowShape(Shape obj)
        {
            if (obj.Name == "Rectangle")
            {
                return (Rectangle) obj;
            }

            if (obj.Name == "Circle")
            {
                return (Ellipse) obj;
            }

            if (obj.Name == "Triangle")
            {
                return (Polygon) obj;
            }

            return null;
        }

        public string FreeTextInput
        {
            get { return textIn; }
            set
            {
                if (textIn == value) return;
                textIn = value;
                //send the new text value to the stringInput View MOdel for processing,
                txtInputViewModel.ShapeDescription = textIn;
                OnPropertyChanged(nameof(FreeTextInput));
            }
        }

        //will pass and recieve shapesDrawerViewModel
        public Shape DrawShape
        {
            get
            {
                return shapesDrawerViewModel.DrawShape;
            }
            set
            {
                if (Equals(shapesDrawerViewModel.DrawShape, value)) return;
                shapesDrawerViewModel.DrawShape = value;
                OnPropertyChanged(nameof(DrawShape));
            }
        }

        public void Dispose()
        {
            ShapeCreatedReadyToPaint -= DrawShapeToScreen;
        }
    }
}