using System;
using System.Collections.Generic;
using jeylabsCodeReviews.uttils;
using jeylabsCodeReviews.ViewModels;

namespace jeylabsCodeReviews.Models
{
    public class ShapesModel : ObservableObject
    {
        private int width;
        private int height;
        private List<int> points;

        public ShapesModel()
        {
            Console.WriteLine("Inside the Model Ctor.");
            width = 0;
            height = 0;
            points = new List<int>();
        }

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
    }
}