using Sample.Helpers;
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
		List<Post> posts = new List<Post>();

        public MainPage()
        {
            InitializeComponent();
			BindingContext = _vm = new MainViewModel();

            posts.Add(new Post() { Title = "Item 1", Text = LoremIpsum(10, 30, 1, 2, 1) });
            posts.Add(new Post() { Title = "Item 2", Text = LoremIpsum(10, 50, 1, 3, 2) });
            posts.Add(new Post() { Title = "Item 3", Text = LoremIpsum(10, 30, 1, 2, 1) });
            posts.Add(new Post() { Title = "Item 4", Text = LoremIpsum(10, 50, 1, 2, 5) });
            posts.Add(new Post() { Title = "Item 5", Text = LoremIpsum(10, 50, 1, 3, 1) });
            posts.Add(new Post() { Title = "Item 6", Text = LoremIpsum(10, 30, 1, 2, 1) });
            posts.Add(new Post() { Title = "Item 7", Text = LoremIpsum(10, 50, 3, 5, 2) });
            posts.Add(new Post() { Title = "Item 8", Text = LoremIpsum(10, 50, 2, 4, 1) });
            posts.Add(new Post() { Title = "Item 9", Text = LoremIpsum(10, 30, 1, 2, 1) });
          
            lstView.ItemsSource = posts;
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
			Post post = (Post)m.BindingContext;
			DisplayAlert("Edit", "Do some action to edit " + post.Title, "OK");
        }

		void ShareViewCellClicked(ViewCell m, EventArgs e)
        {
            Post post = (Post)m.BindingContext;
			DisplayAlert("Share", "Do some action to share " + post.Title, "OK");
        }
        
		void ViewCellTap(ViewCell m, EventArgs eventArgs)
		{
			Post post = (Post)m.BindingContext;
			HideAllButtons(post);
			lstView.SelectedItem = null;
			m.ForceUpdateSize();
		}

        protected void HideAllButtons(Post post)
		{
			foreach (Post p in posts)
            {
                p.visibleButtons = (post == p) ? true : false;
            }
		}

		async void Phone_Tapped(object sender, EventArgs e)
		{
            await Util.FadeStackLayoutTap(sender);
        }

		async void Send_Tapped(object sender, EventArgs e)
        {
            await Util.FadeStackLayoutTap(sender);
        }

		async void Media_Tapped(object sender, EventArgs e)
        {
            await Util.FadeStackLayoutTap(sender);
        }

		async void Settings_Tapped(object sender, EventArgs e)
        {
            await Util.FadeStackLayoutTap(sender);
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
