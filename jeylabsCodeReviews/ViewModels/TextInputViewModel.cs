using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using System.Windows.Shapes;
using jeylabsCodeReviews.uttils;

namespace jeylabsCodeReviews.ViewModels
{
    public class TextInputViewModel : ObservableObject
    {
        private string shapeDescription;
        private ShapeDrawerViewModel shapesDrawerVm;

        public TextInputViewModel(ShapeDrawerViewModel shapesDrawerViewModel)
        {
            shapesDrawerVm = shapesDrawerViewModel;
            shapeDescription = "";
        }

        public string ShapeDescription
        {
            get { return shapeDescription; }
            set
            {
                if (string.Equals(shapeDescription, value)) return;
                shapeDescription = value;
                Console.WriteLine(MainWindowResources.TextInputViewModel_ShapeDescription_, shapeDescription);

                var processedWords = ProcessString(shapeDescription);

                OnPropertyChanged(nameof(ShapeDescription));
            }
        }

        public List<string> ProcessString(string enteredStringValue)
        {
            //Split string by words
            var matches = Regex.Matches(enteredStringValue, @"\w+[^\s]*\w+|\w");
            var words = new List<string>();

            foreach (Match match in matches)
            {
                var word = match.Value;

                words.Add(word);

                if (word.ToLower() == "rectangle")
                {
                    shapesDrawerVm.DrawShape = new Rectangle();
                }
                else if (word.ToLower() == "circle")
                {
                    shapesDrawerVm.DrawShape = new Ellipse();
                }
                else if (word.ToLower() == "triangle")
                {
                    shapesDrawerVm.DrawShape = new Polygon();
                }



            }
            //use linq to search for words from key words in model

            //pass the shape, (width, height, radius,) => default value params = width =0, etc.


            return words;
        }
    }
}