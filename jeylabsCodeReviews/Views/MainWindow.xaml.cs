using System.Windows;
using System.Windows.Shapes;

namespace jeylabsCodeReviews.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ShapeDrawerPageViewModel pageViewModel;
        public MainWindow()
        {
            InitializeComponent();
            //Set View Model To handle data input / output
            
            pageViewModel = new ShapeDrawerPageViewModel();
            DataContext = pageViewModel;

            Shape funnyStuff = pageViewModel.DrawShape;

            ShapeDrawingCanvas.Children.Add(funnyStuff);
        }
    }
}
