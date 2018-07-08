using jeylabsCodeReviews.ViewModels;
using System;
using System.Windows.Shapes;
using jeylabsCodeReviews.Models;
using jeylabsCodeReviews.uttils;

namespace jeylabsCodeReviews
{
    public class ShapeDrawerPageViewModel : ObservableObject
    {
        private TextInputViewModel txtInputViewModel;
        private ShapeDrawerViewModel shapesDrawerViewModel;
        private ShapesModel shapesModel;

        private string textIn;
        private Shape canvasDrawing;

        private Action<Shape> ShapeCreatedReadyToPaint;

        public ShapeDrawerPageViewModel()
        {
            //TODO: Remove all Debug lines.
            Console.WriteLine(MainWindowResources.MainPageViewModel_ConstructorDebug);
            textIn = "";
            canvasDrawing = new Rectangle();            
            ShapeCreatedReadyToPaint += DrawShapeToScreen;

            shapesDrawerViewModel = new ShapeDrawerViewModel();
            shapesModel = new ShapesModel();
            txtInputViewModel = new TextInputViewModel(shapesDrawerViewModel);
        }

        private void DrawShapeToScreen(Shape obj)
        {
            Console.WriteLine("The new Shape to draw is " + obj);



            shapesDrawerViewModel.DrawShape = obj;


        }

        public Shape ShowShape(Shape obj)
        {
            if (obj.Name == "Rectangle")
            {
                return (Rectangle) obj;
            }
            else if (obj.Name == "Circle")
            {
                return (Ellipse) obj;
            }

            return null;
        }

        public string FreeTextInput
        {
            get
            {
                Console.WriteLine("Returning To Screen:: " + textIn);
                return textIn;
            }
            set
            {
                if (textIn == value) return;
                textIn = value;
                //send the new text value to the stringInput View MOdel for processing,
                txtInputViewModel.ShapeDescription = textIn;
                Console.WriteLine("SETTING textIn to:: " + textIn);
                OnPropertyChanged("FreeTextInput");
            }
        }

        //will pass and recieve shapesDrawerViewModel
        public Shape DrawShape
        {
            get
            {
                return shapesDrawerViewModel.DrawShape;
            }
            set
            {
                if (Equals(shapesDrawerViewModel.DrawShape, value)) return;
                shapesDrawerViewModel.DrawShape = value;
                OnPropertyChanged("DrawShape");

            }
        }
    }
}