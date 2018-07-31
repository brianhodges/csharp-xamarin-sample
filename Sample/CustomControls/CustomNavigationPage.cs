using System;
using Xamarin;
using Xamarin.Forms;

namespace Sample.CustomControls
{
    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage(Page root) : base(root)
        {
            BarTextColor = Color.White;
            BarBackgroundColor = Color.FromHex("#666666");
        }
    }
}
