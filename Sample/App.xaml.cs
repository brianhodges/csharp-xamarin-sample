using Sample.CustomControls;
using Sample.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Sample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var page = new MasterDetailPage()
            {
                Master = new SidePanel() { Title = "Main Page" },
                Detail = new CustomNavigationPage(new MainPage())
            };

            MainPage = page;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
