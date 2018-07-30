using Sample.Models;
using Sample.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Sample.Pages
{
    public partial class MainPage : ContentPage
    {
		MainViewModel _vm;
		List<Item> items = new List<Item>();

        public MainPage()
        {
            InitializeComponent();
			BindingContext = _vm = new MainViewModel();

			items.Add(new Item() { Name = "Item 1", Description = LoremIpsum(10, 30, 1, 2, 1) });
			items.Add(new Item() { Name = "Item 2", Description = LoremIpsum(10, 50, 1, 3, 2) });
			items.Add(new Item() { Name = "Item 3", Description = LoremIpsum(10, 30, 1, 2, 1) });
			items.Add(new Item() { Name = "Item 4", Description = LoremIpsum(10, 50, 1, 2, 5) });
			items.Add(new Item() { Name = "Item 5", Description = LoremIpsum(10, 50, 1, 3, 1) });
			items.Add(new Item() { Name = "Item 6", Description = LoremIpsum(10, 30, 1, 2, 1) });
			items.Add(new Item() { Name = "Item 7", Description = LoremIpsum(10, 50, 3, 5, 2) });
			items.Add(new Item() { Name = "Item 8", Description = LoremIpsum(10, 50, 2, 4, 1) });
			items.Add(new Item() { Name = "Item 9", Description = LoremIpsum(10, 30, 1, 2, 1) });
          
			lstView.ItemsSource = items;
        }

		protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
			carousel.HeightRequest = (width > height) ? 150 : 250;
        } 

		void Handle_PositionSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {
            Debug.WriteLine("Position " + e.NewValue + " selected.");
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
			HideAllButtons(item);
			lstView.SelectedItem = null;
			m.ForceUpdateSize();
		}

        protected void HideAllButtons(Item item)
		{
			foreach (Item i in items)
            {
                i.visibleButtons = (item == i) ? true : false;
            }
		}

		void Phone_Tapped(object sender, EventArgs e)
		{
			DisplayAlert("Phone", "", "OK");
		}

		void Send_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Message", "", "OK");
        }

		void Media_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Media", "", "OK");
        }

		void Settings_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Settings", "", "OK");
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
}
