using System.ComponentModel;

namespace jeylabsCodeReviews.uttils
{

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
