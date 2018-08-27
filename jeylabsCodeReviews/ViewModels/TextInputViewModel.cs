using System.Collections.Generic;
using System.Text.RegularExpressions;
using jeylabsCodeReviews.Models;

namespace jeylabsCodeReviews.ViewModels
{
    /// <summary>
    /// TextInputViewModel Class
    /// This is the main user input analysis class
    /// It will take in the string the user enters on the UI
    /// break that down into an array of matches on the key words
    /// needed to build the shape.
    /// These Matches are part of the Regex lib and is a way to both
    /// break and string down and search for keywords or patterns.
    /// I chose to split all words into matches and pull out
    /// Shape name, Width, Height and pass this to the shapeDrawerVM
    /// for creation of shapes.
    /// </summary>
    public class TextInputViewModel
    {
        private string shapeDescription;
        private readonly ShapeDrawerViewModel shapesDrawerVm;

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
                ProcessString(shapeDescription);               
            }
        }

        //process user input passed from view model
        private void ProcessString(string enteredStringValue)
        {
            //Split string by words
            MatchCollection matches = Regex.Matches(enteredStringValue, @"\w+[^\s]*\w+|\w");
            var words = new List<string>();

            //Store the words in a List of strings for analysis
            foreach (Match match in matches)
            {
                words.Add(match.Value.ToLower());
            }

            //set invalid int's used later in validation for shape creation.
            int width = -1;
            int height = -1;


            //we know text input syntax will follow an example of:
            //Draw a/(n) <shape> with a/(n) <measurement> of <amount>
            // and a/(n) <Measurement> of <amount>
            //The height and width may be swapped in their placement or order of appearance
            //both W x H or H x W are valid inputs.
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

            //Now find the type of shape required and create it using the width and height
            //minor validation if width and height are not positive numbers no shape is built.
            if (words.Contains("rectangle") || words.Contains("square"))
            {
                var myRect = new ShapesModel { Name = "rectangle", Width = width > -1 ? width : 0, Height = height > -1 ? height : 0};
                shapesDrawerVm.BeginDrawShape = ShapesModel.ConvertToRectangle(myRect);
            }
            else if (words.Contains("circle") || words.Contains("oval"))
            {
                var myCircle = new ShapesModel { Name = "circle", Width = width > -1 ? width : 0, Height = height > -1 ? height : 0 }; 
                shapesDrawerVm.BeginDrawShape = ShapesModel.ConvertToEllipse(myCircle);
            }
            else if (words.Contains("triangle"))
            {
                var myTriangle = new ShapesModel { Name = "triangle", Width = width > -1 ? width : 0, Height = height > -1 ? height : 0 };
                shapesDrawerVm.BeginDrawShape = ShapesModel.ConvertToPolygon(myTriangle);
            }
        }
    }
}