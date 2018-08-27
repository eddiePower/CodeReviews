using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using jeylabsCodeReviews.uttils;

namespace jeylabsCodeReviews.ViewModels
{
    /// <summary>
    /// This class is used as a joining class it takes in
    /// user text input and passes the shape back to be
    /// drawn to the screen / UI.
    /// The user text input is bound the View from this view model.
    /// ShapeCreatedReadyToPaint Action or event is how the
    /// UI / screen is updated or painted when the enter key is hit
    /// and the input is formed correctly (syntax).
    /// The shape is created and passed back to the Draw Shape to screen
    /// method.
    /// </summary>
    public class ShapeDrawerPageViewModel : ObservableObject, IDisposable
    {
        private readonly TextInputViewModel txtInputViewModel;
        private readonly ShapeDrawerViewModel shapesDrawerViewModel;
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
        /// <param name="obj">A Base Shape - Ellipse, Rectangle, Polygon</param>
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
                    polygon.Points = new PointCollection(new[] { new Point(0, obj.Height), new Point(obj.Height, 0), new Point(obj.Height, obj.Width) });

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
            get => textIn;

            set
            {
                if (textIn == value) return;
                textIn = value;
                //send the new text value to the stringInput View MOdel for processing,
                txtInputViewModel.ShapeDescription = textIn;

                //Debug text output.
               // Console.WriteLine("UserText sent in was: " + txtInputViewModel.ShapeDescription);

                //inform the view-model something has changed
                OnPropertyChanged(nameof(FreeTextInput));
            }
        }

        //will pass and receive shapesDrawerViewModel base shape.
        //And will draw the shape onto the UI or screen.
        //Is Called from the 
        public Shape DrawShape
        {
            get => shapesDrawerViewModel.BeginDrawShape;

            private set
            {
                if (Equals(shapesDrawerViewModel.BeginDrawShape, value)) return;
                shapesDrawerViewModel.BeginDrawShape = value;

                //inform the UI - View that a new shape is ready to paint to screen.
                OnPropertyChanged(nameof(DrawShape));
            }
        }

        // Part of the IDisposable and is used to unhook and clear and assigned memory
        // for user created code not part of the general Garbage Collection.
        // Events / Actions, Objects / Classes and other similar.
        public void Dispose()
        {
            ShapeCreatedReadyToPaint -= DrawShapeToScreen;
        }
    }
}