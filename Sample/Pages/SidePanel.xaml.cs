using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Models;
using Sample.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SidePanel : ContentPage
	{
        List<SideNavLink> links = new List<SideNavLink>();
		public SidePanel()
		{
			InitializeComponent();

            links.Add(new SideNavLink { Title = "Baseball", FontAwesomeIcon = FontAwesomeIcons.Baseball });
            links.Add(new SideNavLink { Title = "Basketball", FontAwesomeIcon = FontAwesomeIcons.Basketball });
            links.Add(new SideNavLink { Title = "Bowling", FontAwesomeIcon = FontAwesomeIcons.Bowling });
            links.Add(new SideNavLink { Title = "Fitness", FontAwesomeIcon = FontAwesomeIcons.Fitness });
            links.Add(new SideNavLink { Title = "Football", FontAwesomeIcon = FontAwesomeIcons.Football });
            links.Add(new SideNavLink { Title = "Golf", FontAwesomeIcon = FontAwesomeIcons.Golf });
            links.Add(new SideNavLink { Title = "Hockey", FontAwesomeIcon = FontAwesomeIcons.Hockey });
            links.Add(new SideNavLink { Title = "Soccer", FontAwesomeIcon = FontAwesomeIcons.Soccer });
            links.Add(new SideNavLink { Title = "Table Tennis", FontAwesomeIcon = FontAwesomeIcons.TableTennis });
            links.Add(new SideNavLink { Title = "Volleyball", FontAwesomeIcon = FontAwesomeIcons.Volleyball });

            lstView.ItemsSource = links;
		}

        void ViewCellTap(object sender, EventArgs e)
        {
            lstView.SelectedItem = null;
        }
	}
}