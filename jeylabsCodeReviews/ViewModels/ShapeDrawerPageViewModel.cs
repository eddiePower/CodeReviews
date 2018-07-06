using jeylabsCodeReviews.ViewModels;
using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace jeylabsCodeReviews
{
    public class ShapeDrawerPageViewModel : ObservableObject
    {
        private string textIn;
        private Shape canvasDrawing;
        private Ellipse circleDrawing;
        private Rectangle rectangleDrawing;
        private Polygon triangleDrawing;

        public ShapeDrawerPageViewModel()
        {
            Console.WriteLine("Inside Constructor for ShapePageViewModel.");
            textIn = "";
            rectangleDrawing = new Rectangle();
            canvasDrawing = rectangleDrawing;
            circleDrawing = new Ellipse();
            triangleDrawing = new Polygon();
        }

        public string FreeTextInput
        {
            get
            {
                return textIn;
            }
            set
            {
                if (textIn == value) return;
                textIn = value;

                //clean up with string toLower and one search
                if (textIn == "Rectangle" || textIn == "rectangle")
                {
                    canvasDrawing = rectangleDrawing;
                    canvasDrawing.Width = 95;
                    canvasDrawing.Height = 165;
                    canvasDrawing.Stroke = new SolidColorBrush(Colors.Black);
                    canvasDrawing.Fill = new SolidColorBrush(Colors.White);
                    rectangleDrawing = (Rectangle) canvasDrawing;
                    canvasDrawing = null;
                    DrawShape = rectangleDrawing;
                } //Also add in elipse and other circle names.
                else if(textIn == "Circle" || textIn == "circle")
                {
                    Console.WriteLine("The Circle Drawing has been chosen now painting to screen.");
                    canvasDrawing = circleDrawing;
                    canvasDrawing.Stroke = new SolidColorBrush(Colors.Black);
                    canvasDrawing.Fill = new SolidColorBrush(Colors.White);
                    canvasDrawing.StrokeThickness = 2;

                    // Set the width and height of the Ellipse.
                    canvasDrawing.Width = 200;
                    canvasDrawing.Height = 100;
                    circleDrawing = (Ellipse) canvasDrawing;
                    canvasDrawing = null;
                    DrawShape = circleDrawing;
                }
                
                OnPropertyChanged("FreeTextInput");
            }
        }

        //will change to sub class shape
        public Shape DrawShape
        {
            get
            {
                return canvasDrawing;
            }
            set
            {
                if (canvasDrawing == value) return;
                canvasDrawing = value;
                OnPropertyChanged("DrawShape");

            }
        }
    }
}