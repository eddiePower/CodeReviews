using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace jeylabsCodeReviews.Models
{
    /// <summary>
    /// Main Data Model for the Shapes created
    /// This is also probably not needed but a good demonstration
    /// of the Models role in MVVM type C# development.
    /// Holds the shape name, width, height, and a points array
    /// for future use in triangle / polygon creation
    /// </summary>
    public class ShapesModel
    {
        private int width;
        private int height;
        private PointCollection points;
        private string name;

        public ShapesModel()
        {
            name = "shape";
            width = 0;
            height = 0;
            points = new PointCollection(); //used in polygon shapes.
        }

        //Names used for shape creation such as rectangle etc
        public string Name
        {
            private get => name;
            set
            {
                if (string.Equals(name, value)) return;
                name = value;               
            }
        }

        //Width property used for Shape creation
        public int Width
        {
            private get => width;
            set
            {
                if (Equals(width, value)) return;
                width = value;            
            }
        }

        //height property used for shape creation
        public int Height
        {
            private get => height;
            set
            {
                if (Equals(height, value)) return;
                height = value;                
            }
        }

        //point collection are used to create polygon shapes
        // will be a set of points eg new Point(0, 40);
        public PointCollection Points
        {
            get => points;
            set
            {
                if (Equals(points, value)) return;
                points = value;             
            }
        }

        //method to turn this shape model into a rectangle
        //rather then inheriting from the shape class and its overhead.
        public static Rectangle ConvertToRectangle(ShapesModel v)
        {
            var rect = new Rectangle { Name = v.Name, Width = v.Width, Height = v.Height };
            return rect;
        }

        //Used to turn this model into a circle or ellipse.
        public static Ellipse ConvertToEllipse(ShapesModel v)
        {
            var circle = new Ellipse { Name = v.Name, Width = v.Width, Height = v.Height };
            return circle;
        }

        //Used to turn this model into a polygon shape.
        public static Polygon ConvertToPolygon(ShapesModel v)
        {
            var triangle = new Polygon { Name = v.Name, Width = v.Width, Height = v.Height };      
            return triangle;
        }

        //TODO: ADD IN VALIDATION FOR SQUARE AND RECTANGLES / OVAL TO CIRCLE etc, 
        public bool IsSquare(Rectangle rect) => Math.Abs(rect.Height - rect.Width) < 0.001;
    }
}