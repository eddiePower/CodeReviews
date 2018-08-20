using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Shapes;
using jeylabsCodeReviews.ViewModels;

namespace jeylabsCodeReviews.Views
{
    /// <summary>
    /// The ONLY code in this file relates to:
    /// A: Bind the ViewModel to the UI (This View).
    /// B: Perform any UI formating like colors, headings, UI only logic
    ///      no business logic here! no Anti Patterns.
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
        }

        //The key binding to the enter key to trigger the create and draw shape from the user
        //input in the syntax of Draw a/n shape with a height or n and a width of n.  these height 
        // and width keywords can be interchanged. Shapes so far are Circle, oval, square,
        // rectangle, Triangle.
        private void TextBox_KeyEnterUpdate(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox tBox = (TextBox)sender;
                DependencyProperty prop = TextBox.TextProperty;

                //Found on stack to allow dynamic binding / updating the ui.
                BindingExpression binding = BindingOperations.GetBindingExpression(tBox, prop);
                if (binding != null)
                {
                    binding.UpdateSource();
                }


                //clear the canvas UI Element ready to draw a new shape.
                ShapeDrawingCanvas.Children.Clear();

                //Test the Data type of the shape held in the main page view model
                // if its a rect, circle, or triangle then add it to the canvas - i.e. draw it.
                if (pageViewModel.DrawShape is Rectangle rectangle)
                {
                    ShapeDrawingCanvas.Children.Add(rectangle);
                }
                else if (pageViewModel.DrawShape is Ellipse ellipse)
                {
                    ShapeDrawingCanvas.Children.Add(ellipse);
                }
                else if (pageViewModel.DrawShape is Polygon polygon)
                {
                    ShapeDrawingCanvas.Children.Add(polygon);
                }
            }
        }
    }
}
