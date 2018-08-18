using System.Windows.Media;
using System.Windows.Shapes;
using jeylabsCodeReviews.uttils;

namespace jeylabsCodeReviews.Models
{
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

        public string Name { get; set; }

        public int Width
        {
            get { return width; }
            set
            {
                if (width == value) return;
                width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        public int Height
        {
            get { return height; }
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
                if (points == value) return;
                points = value;
                OnPropertyChanged(nameof(Points));
            }
        }

        public static explicit operator Rectangle(ShapesModel v)
        {
            var rect = new Rectangle { Name = v.Name, Width = v.Width, Height = v.Height };

            return rect;
        }

        public static explicit operator Ellipse(ShapesModel v)
        {
            var circle = new Ellipse { Name = v.Name, Width = v.Width, Height = v.Height };

            return circle;
        }

        public static explicit operator Polygon(ShapesModel v)
        {
            var triangle = new Polygon { Name = v.Name, Width = v.Width, Height = v.Height };

            return triangle;
        }
    }
}