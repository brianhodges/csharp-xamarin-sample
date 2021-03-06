﻿using Newtonsoft.Json;
using Sample.Helpers;
using Sample.Models;
using Sample.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

            FetchNewPosts();
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
            DisplayAlert("Edit", "Do some action to edit Post #" + post.ID, "OK");
        }

		void ShareViewCellClicked(ViewCell m, EventArgs e)
        {
            Post post = (Post)m.BindingContext;
            DisplayAlert("Share", "Do some action to share Post #" + post.ID, "OK");
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

        protected void FetchNewPosts()
        {
            string apiUrl = "https://golang-dummydata.herokuapp.com/data.json";
            var response = Util.Get(apiUrl);
            posts = JsonConvert.DeserializeObject<List<Post>>(response);
            lstView.ItemsSource = posts;
        }

        async void Handle_Refreshing(object sender, EventArgs e)
        {
            lstView.IsRefreshing = true;
            lstView.ItemsSource = null;
            await Task.Delay(1000);
            FetchNewPosts();
            lstView.IsRefreshing = false;
        }

        void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                lstView.ItemsSource = posts;
            }
            else
            {
                lstView.ItemsSource = posts.Where(p => p.Text.ToLower().Contains(e.NewTextValue.ToLower()) || 
                                        p.Title.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }

        async void SearchBar_Unfocused(object sender, FocusEventArgs e)
        {
            searchBar.IsVisible = false;
            await stackLayout.FadeTo(1.0, 125);
        }

        async void Search_Tapped(object sender, EventArgs args)
        {
            searchBar.IsVisible = true;
            await stackLayout.FadeTo(0.8, 125);
            searchBar.Focus();
        }
    }
}
