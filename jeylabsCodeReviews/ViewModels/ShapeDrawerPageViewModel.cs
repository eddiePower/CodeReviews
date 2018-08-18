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

        /// <summary>
        /// Main Shape creation method
        /// begins the draw shape to the screen.
        /// </summary>
        /// <param name="obj">Base Shape - Ellipse, Rectangle, Polygon</param>
        //Switch on the Shape Name property passed into
        private void DrawShapeToScreen(Shape obj)
        {
            switch (obj.Name)
            {
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
                    polygon.Points = new PointCollection(new[] { new Point(0, 40), new Point(40, 0), new Point(40,90) });
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

        /// <summary>
        /// Bound to the free text entry field
        /// on the mainWindow View.
        /// Takes in user input to be sorted and stored
        /// input must follow the set guideline shown on main window
        /// </summary>
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