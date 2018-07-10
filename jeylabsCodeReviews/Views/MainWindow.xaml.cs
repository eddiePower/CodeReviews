using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Shapes;
using jeylabsCodeReviews.ViewModels;

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
        }

        private void TextBox_KeyEnterUpdate(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox tBox = (TextBox)sender;
                DependencyProperty prop = TextBox.TextProperty;

                BindingExpression binding = BindingOperations.GetBindingExpression(tBox, prop);
                if (binding != null)
                {
                    binding.UpdateSource();
                }

                ShapeDrawingCanvas.Children.Clear();

                if (pageViewModel.DrawShape is Rectangle)
                {
                    ShapeDrawingCanvas.Children.Add((Rectangle) pageViewModel.DrawShape);
                }
                else if (pageViewModel.DrawShape is Ellipse)
                {
                    ShapeDrawingCanvas.Children.Add((Ellipse) pageViewModel.DrawShape);
                }
                else if (pageViewModel.DrawShape is Polygon)
                {
                    ShapeDrawingCanvas.Children.Add((Polygon) pageViewModel.DrawShape);
                }
            }
        }
    }
}
