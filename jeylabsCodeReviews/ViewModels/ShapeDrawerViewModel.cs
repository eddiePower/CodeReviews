using System.Windows.Shapes;
using jeylabsCodeReviews.uttils;

namespace jeylabsCodeReviews.ViewModels
{
    public class ShapeDrawerViewModel : ObservableObject
    {
        private Shape baseShape;
        private ShapeDrawerPageViewModel shapeDraweringPageViewModel;


        public ShapeDrawerViewModel(ShapeDrawerPageViewModel mainPageViewModel)
        {
            shapeDraweringPageViewModel = mainPageViewModel;
        }

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