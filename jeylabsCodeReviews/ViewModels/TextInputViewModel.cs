using System;
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

                OnPropertyChanged(nameof(ShapeDescription));
            }
        }

        public string ProcessString(string enteredStringValue)
        {
            //Split string by words

            //use linq to search for words from key words in model

            //pass the shape, (width, height, radius,) => default value params = width =0, etc.
            

            return "";
        }
    }
}