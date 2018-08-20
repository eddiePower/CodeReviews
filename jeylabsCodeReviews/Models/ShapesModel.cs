using System.Windows.Media;
using System.Windows.Shapes;
using jeylabsCodeReviews.uttils;

namespace jeylabsCodeReviews.Models
{
    /// <summary>
    /// Main Data Model for the Shapes created
    /// This is also probably not needed but a good demonstration
    /// of the Models role in MVVM type C# dev.
    /// Holds the shape name, width, height, and a points array
    /// for future use in triangle / polygon creation
    /// </summary>
    public class ShapesModel : ObservableObject
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
            points = new PointCollection();
        }

        public string Name
        {
            get => name;
            set
            {
                if (name == value) return;
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Width
        {
            get => width;
            set
            {
                if (width == value) return;
                width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        public int Height
        {
            get => height;
            set
            {
                if (height == value) return;
                height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        public PointCollection Points
        {
            get { return points; }
            set
            {
                if (Equals(points, value)) return;
                points = value;
                OnPropertyChanged(nameof(Points));
            }
        }

        public static Rectangle ConvertToRectangle(ShapesModel v)
        {
            var rect = new Rectangle { Name = v.Name, Width = v.Width, Height = v.Height };
            return rect;
        }

        public static Ellipse ConvertToEllipse(ShapesModel v)
        {
            var circle = new Ellipse { Name = v.Name, Width = v.Width, Height = v.Height };
            return circle;
        }

        public static Polygon ConvertToPolygon(ShapesModel v)
        {
            var triangle = new Polygon { Name = v.Name, Width = v.Width, Height = v.Height };
            return triangle;
        }
    }
}