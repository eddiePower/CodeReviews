using System.ComponentModel;

namespace jeylabsCodeReviews.uttils
{
    /// <summary>
    /// My OnProperty Changed class - This is so we can have multiple classes
    /// using the INotify event to update the UI when the user makes changes, or
    /// a class makes changes to data on the UI.
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            //check the event above has been created with content
            //set the property name with this class
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
