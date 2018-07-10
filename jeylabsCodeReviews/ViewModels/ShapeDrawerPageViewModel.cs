using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using jeylabsCodeReviews.Models;
using jeylabsCodeReviews.uttils;

namespace jeylabsCodeReviews.ViewModels
{
    public class ShapeDrawerPageViewModel : ObservableObject, IDisposable
    {
        private TextInputViewModel txtInputViewModel;
        private ShapeDrawerViewModel shapesDrawerViewModel;
        private ShapesModel shapesModel;

        private string textIn;
        private Shape canvasDrawing;

        public Action<Shape> ShapeCreatedReadyToPaint;

        public ShapeDrawerPageViewModel()
        {
            textIn = "";
            canvasDrawing = new Rectangle();            
            ShapeCreatedReadyToPaint += DrawShapeToScreen;

            shapesDrawerViewModel = new ShapeDrawerViewModel(this);
            shapesModel = new ShapesModel();
            txtInputViewModel = new TextInputViewModel(shapesDrawerViewModel);
        }

        private void DrawShapeToScreen(Shape obj)
        {
            //ToDo:  Replace Colours with variables retrieved from 
            // ToDo: the string sort / processing.
            if (obj.Name == "rectangle" && obj is Rectangle rectangle)
            {
                rectangle.Stroke = new SolidColorBrush(Colors.Black);
                rectangle.Fill = new SolidColorBrush(Colors.AliceBlue);

                DrawShape = rectangle;
            }
            else if (obj.Name== "circle" && obj is Ellipse ellipse)
            {
                ellipse.Stroke = new SolidColorBrush(Colors.Black);
                ellipse.Fill = new SolidColorBrush(Colors.AliceBlue);

                DrawShape = ellipse;
            }
            else if(obj.Name == "Triangle" && obj is Polygon polygon)
            {
                polygon.Points = new PointCollection(new[] {new Point(0, 40), new Point(40, 0), new Point(40,90)});
                polygon.Stroke = new SolidColorBrush(Colors.Black);
                polygon.Fill = new SolidColorBrush(Colors.AliceBlue);

                DrawShape = polygon;
            }
            else if (obj.Name == "oval" && obj is Ellipse oval)
            {
                oval.Stroke = new SolidColorBrush(Colors.Black);
                oval.Fill = new SolidColorBrush(Colors.AliceBlue);

                DrawShape = oval;
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