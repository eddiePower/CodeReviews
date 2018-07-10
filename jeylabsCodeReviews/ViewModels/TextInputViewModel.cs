using System.Collections.Generic;
using System.Text.RegularExpressions;
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
                //Store the words in a List of strings for analysis
                //we know it will follow the set syntax of
                //Draw a/(n) <shape> with a/(n) <measurement> of <amount>
                // and a/(n) <Measurement> of <amount>
                words.Add(((string) match.Value).ToLower());
            }

                int width = -1;
                int height = -1;
                
                if (words.Contains("rectangle"))
                {
                    if (words.Contains("width"))
                    {
                        var loc = words.IndexOf("width");
                        int.TryParse(words[loc + 2], out width);
                    }

                    if (words.Contains("height"))
                    {
                        var loc = words.IndexOf("height");
                        int.TryParse(words[loc + 2], out height);
                    }

                    var myRect = new Rectangle {Name = "rectangle", Width = width > -1 ? width : 0, Height = height > -1 ? height : 0};

                    shapesDrawerVm.DrawShape = myRect;
                }
                else if (words.Contains("circle"))
                {
                    if (words.Contains("width"))
                    {
                        var loc = words.IndexOf("width");
                        int.TryParse(words[loc + 2], out width);
                    }

                    if (words.Contains("height"))
                    {
                        var loc = words.IndexOf("height");
                        int.TryParse(words[loc + 2], out height);
                    }

                var myCircle = new Ellipse {Name = "circle", Width = width, Height = height};

                    shapesDrawerVm.DrawShape = myCircle;
                }
                else if (words.Contains("triangle"))
                {
                    if (words.Contains("width"))
                    {
                        var loc = words.IndexOf("width");
                        int.TryParse(words[loc + 2], out width);
                    }

                    if (words.Contains("height"))
                    {
                        var loc = words.IndexOf("height");
                        int.TryParse(words[loc + 2], out height);
                    }

                    var myTriangle = new Polygon {Name = "triangle", Width = width, Height = height};

                    shapesDrawerVm.DrawShape = myTriangle;
                }
                else if (words.Contains("oval"))
                {
                    if (words.Contains("width"))
                    {
                        var loc = words.IndexOf("width");
                        int.TryParse(words[loc + 2], out width);
                    }

                    if (words.Contains("height"))
                    {
                        var loc = words.IndexOf("height");
                        int.TryParse(words[loc + 2], out height);
                    }

                    var myOval = new Ellipse {Name = "oval", Width = width, Height = height};

                    shapesDrawerVm.DrawShape = myOval;
                }            

            return words;
        }
    }
}