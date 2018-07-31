using System.ComponentModel;

namespace Sample.Models
{
    public class Post : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Username { get; set; }
        public string Source { get; set; }
        public string DateTimeCreated { get; set; }
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
