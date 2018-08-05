using FFImageLoading.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace Sample.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            MyItemsSource = new ObservableCollection<View>()
            {
                new CachedImage() { Source = "slide1.jpg", DownsampleToViewSize = false, Aspect = Aspect.AspectFill },
                new CachedImage() { Source = "slide2.jpg", DownsampleToViewSize = false, Aspect = Aspect.AspectFill },
                new CachedImage() { Source = "slide3.jpg", DownsampleToViewSize = false, Aspect = Aspect.AspectFill },
				new CachedImage() { Source = "slide4.jpg", DownsampleToViewSize = false, Aspect = Aspect.AspectFill }
            };
        }

        ObservableCollection<View> _myItemsSource;
        public ObservableCollection<View> MyItemsSource
        {
            set
            {
                _myItemsSource = value;
                OnPropertyChanged("MyItemsSource");
            }
            get
            {
                return _myItemsSource;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}