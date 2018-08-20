using System.Windows.Shapes;
using jeylabsCodeReviews.uttils;

namespace jeylabsCodeReviews.ViewModels
{
    /// <summary>
    /// Draw Shapes to screen View model
    /// This VM could be absorbed by the other ShapeDrawerPageViewModel Class
    /// The one method in this class has the main Action to paint the shape to
    /// the screen or ui.
    /// </summary>
    public class ShapeDrawerViewModel : ObservableObject
    {
        private Shape baseShape;
        private ShapeDrawerPageViewModel shapeDraweringPageViewModel;

        //Takes in main view model, this approach allows for multiple components to 
        //all use the one view / ui.
        public ShapeDrawerViewModel(ShapeDrawerPageViewModel mainPageViewModel)
        {
            shapeDraweringPageViewModel = mainPageViewModel;
        }

        //Sets the shape as a subclass of shape - Circle, Rectangle, Triangle.
        //Then calls the main ShapeCreatedReadyToPaint Action passing the shape
        //back to the View / UI ready to be shown to the user in the canvas element.
        public Shape DrawShape
        {
            get { return baseShape; }
            set
            {
                if (Equals(baseShape, value)) return;
                baseShape = value;
                shapeDraweringPageViewModel.ShapeCreatedReadyToPaint?.Invoke(baseShape);
                OnPropertyChanged(nameof(DrawShape));
            }
        }
    }
}