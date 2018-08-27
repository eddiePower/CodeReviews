using System.Windows.Shapes;

namespace jeylabsCodeReviews.ViewModels
{
    /// <summary>
    /// Draw Shapes to screen View model
    /// This VM could be absorbed by the other ShapeDrawerPageViewModel Class
    /// The one method in this class has the main Action to paint the shape to
    /// the screen or UI.
    /// </summary>
    public class ShapeDrawerViewModel
    {
        private Shape baseShape;
        private readonly ShapeDrawerPageViewModel shapeDraweringPageViewModel;

        //Takes in main view model, this approach allows for multiple components to 
        //all use the one view / UI.
        public ShapeDrawerViewModel(ShapeDrawerPageViewModel mainPageViewModel)
        {
            shapeDraweringPageViewModel = mainPageViewModel;
        }

        //Sets the shape as a subclass of shape - Circle, Rectangle, Triangle.
        //Then calls the main ShapeCreatedReadyToPaint Action passing the shape
        //back to the View / UI ready to be shown to the user in the canvas element.
        public Shape BeginDrawShape
        {
            get { return baseShape; }
            set
            {
                if (Equals(baseShape, value)) return;
                baseShape = value;

                //invoke or call the Action ShapeCreatedReadyToPaint passing the current created shape.
                shapeDraweringPageViewModel.ShapeCreatedReadyToPaint?.Invoke(baseShape);
            }
        }
    }
}