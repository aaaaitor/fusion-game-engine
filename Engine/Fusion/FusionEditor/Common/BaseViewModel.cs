using System.ComponentModel;

namespace FusionEditor
{
    /// <summary>
    /// Base class for the view models.
    /// </summary>
    internal class BaseViewModel : INotifyPropertyChanged
    {
        //Event for when a property changes.
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Invokes the "PropertyChanged" event when a change in a property is detected.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}