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
        //main event to be invoked by my code calling the function
        //and trigger a UI update further up the OS / UI stack.
        public event PropertyChangedEventHandler PropertyChanged;

        //main method to invoke a UI update pass the property name that has data to
        //update the UI with. can be set as a one way or 2 way update via binding types in xaml.
        protected void OnPropertyChanged(string propName)
        {
            //check the event above has been created with content
            //set the property name with this class
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
