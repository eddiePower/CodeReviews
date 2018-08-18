using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Shapes;
using jeylabsCodeReviews.Annotations;

namespace jeylabsCodeReviews.Models
{
    public class ShapesModel : Shape, INotifyPropertyChanged
    {
        private int width;
        private int height;
        private List<int> points;
        private string name;

        public ShapesModel()
        {
            name = "shape";
            width = 0;
            height = 0;
            points = new List<int>();
        }

        public new int Width
        {
            get { return width; }
            set
            {
                if (width == value) return;
                width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        public new int Height
        {
            get { return height; }
            set
            {
                if (height == value) return;
                height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        public new string Name
        {
            get { return name; }
            set
            {
                if (name == value) return;
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public List<int> Points
        {
            get { return points; }
            set
            {
                if (points == value) return;
                points = value;
                OnPropertyChanged(nameof(Points));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected override Geometry DefiningGeometry { get; }

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