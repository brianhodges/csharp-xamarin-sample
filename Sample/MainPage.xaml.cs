using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FFImageLoading.Forms;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Sample
{
    public partial class MainPage : ContentPage
    {
		MainViewModel _vm;

        public MainPage()
        {
            InitializeComponent();
			BindingContext = _vm = new MainViewModel();

			Item[] items = {
				new Item(){ Name = "Item 1", Description = LoremIpsum(10, 30, 1, 2, 1) },
				new Item(){ Name = "Item 2", Description = LoremIpsum(10, 50, 1, 3, 2) },
				new Item(){ Name = "Item 3", Description = LoremIpsum(10, 30, 1, 2, 1) },
				new Item(){ Name = "Item 4", Description = LoremIpsum(10, 50, 1, 2, 5) },
				new Item(){ Name = "Item 5", Description = LoremIpsum(10, 50, 1, 3, 1) },
				new Item(){ Name = "Item 6", Description = LoremIpsum(10, 30, 1, 2, 1) },
				new Item(){ Name = "Item 7", Description = LoremIpsum(10, 50, 3, 5, 2) },
				new Item(){ Name = "Item 8", Description = LoremIpsum(10, 50, 2, 4, 1) },
				new Item(){ Name = "Item 9", Description = LoremIpsum(10, 30, 1, 2, 1) }
			};

			lstView.ItemsSource = items;
        }

		void Handle_PositionSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {
            Debug.WriteLine("Position " + e.NewValue + " selected.");
        }

        void Handle_Scrolled(object sender, CarouselView.FormsPlugin.Abstractions.ScrolledEventArgs e)
        {
            Debug.WriteLine("Scrolled to " + e.NewValue + " percent.");
            Debug.WriteLine("Direction = " + e.Direction);
        }

		void EditViewCellClicked(ViewCell m, EventArgs e)
        {
			Item item = (Item)m.BindingContext;
			DisplayAlert("Edit", "Do some action to edit " + item.Name, "OK");
        }

		void ShareViewCellClicked(ViewCell m, EventArgs e)
        {
            Item item = (Item)m.BindingContext;
			DisplayAlert("Share", "Do some action to share " + item.Name, "OK");
        }
        
		void ViewCellTap(ViewCell m, EventArgs eventArgs)
		{
			Item item = (Item)m.BindingContext;
			//item.visibleButtons = true;
			lstView.SelectedItem = null;
		}
      
		string LoremIpsum(int minWords, int maxWords, int minSentences, int maxSentences, int numParagraphs)
        {
            var words = new[]{ "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
                        "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
                        "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat" };

            var rand = new Random();
            int numSentences = rand.Next(maxSentences - minSentences) + minSentences + 1;
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;

            StringBuilder result = new StringBuilder();

            for (int p = 0; p < numParagraphs; p++)
            {
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0) { result.Append(" "); }
                        result.Append(words[rand.Next(words.Length)]);
                    }
                    result.Append(". ");
                }
            }
  
            return result.ToString();
        }      
    }

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
