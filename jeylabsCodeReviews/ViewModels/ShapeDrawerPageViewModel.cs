using jeylabsCodeReviews.ViewModels;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using jeylabsCodeReviews.Models;
using jeylabsCodeReviews.uttils;

namespace jeylabsCodeReviews
{
    public class ShapeDrawerPageViewModel : ObservableObject
    {
        private TextInputViewModel txtInputViewModel;
        private ShapeDrawerViewModel shapesDrawerViewModel;
        private ShapesModel shapesModel;

        private string textIn;
        private Shape canvasDrawing;

        public Action<Shape> ShapeCreatedReadyToPaint;

        public ShapeDrawerPageViewModel()
        {
            //TODO: Remove all Debug lines.
            Console.WriteLine(MainWindowResources.MainPageViewModel_ConstructorDebug);
            textIn = "";
            canvasDrawing = new Rectangle();            
            ShapeCreatedReadyToPaint += DrawShapeToScreen;

            shapesDrawerViewModel = new ShapeDrawerViewModel(this);
            shapesModel = new ShapesModel();
            txtInputViewModel = new TextInputViewModel(shapesDrawerViewModel);
        }

        private void DrawShapeToScreen(Shape obj)
        {
            //ToDo: Replace the Width, Height, and Colours with variables retrieved from 
            // ToDo: the string sort / processing.
            if (obj is Rectangle)
            {
                ((Rectangle) obj).Name = "Rectangle";
                ((Rectangle) obj).Width = 34;
                ((Rectangle) obj).Height = 134;
                ((Rectangle)obj).Stroke = new SolidColorBrush(Colors.Black);
                ((Rectangle)obj).Fill = new SolidColorBrush(Colors.AliceBlue);

                DrawShape = (Rectangle) obj;
            }
            else if (obj is Ellipse)
            {
                ((Ellipse) obj).Name = "Circle";
                ((Ellipse) obj).Width = 34;
                ((Ellipse) obj).Height = 134;
                ((Ellipse) obj).Stroke = new SolidColorBrush(Colors.Black);
                ((Ellipse) obj).Fill = new SolidColorBrush(Colors.AliceBlue);

                DrawShape = (Ellipse) obj;
            }
            else if(obj is Polygon)
            {
                ((Polygon) obj).Name = "Triangle";
                ((Polygon)obj).Points = new PointCollection(new Point[] {new Point(0, 40), new Point(40, 0), new Point(40,90)});
                ((Polygon) obj).Width = 34;
                ((Polygon) obj).Height = 134;
                ((Polygon) obj).Stroke = new SolidColorBrush(Colors.Black);
                ((Polygon)obj).Fill = new SolidColorBrush(Colors.Blue);

                DrawShape = (Polygon) obj;
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
    }
}