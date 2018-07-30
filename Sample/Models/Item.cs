using System.ComponentModel;

namespace Sample.Models
{
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public string Description { get; set; }
        private bool _visibleButtons;
        public bool visibleButtons
        {
            get
            {
                return _visibleButtons;
            }
            set
            {
                _visibleButtons = value;
                OnPropertyChanged("visibleButtons");
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
