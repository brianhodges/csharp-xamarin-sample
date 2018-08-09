using Sample.Helpers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActionButtonNav : ContentView
	{
		public ActionButtonNav()
		{
			InitializeComponent();
		}

        async void Account_Tapped(object sender, EventArgs e)
        {
            await Util.FadeStackLayoutTap(sender);
        }

        async void Messages_Tapped(object sender, EventArgs e)
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
    }
}