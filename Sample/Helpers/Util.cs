using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sample.Helpers
{
    public class Util
    {
        public static async Task FadeStackLayoutTap(object sender)
        {
            StackLayout stackLayout = (StackLayout)sender;
            await stackLayout.FadeTo(0.6, 125);
            await stackLayout.FadeTo(1.0, 125);
            return;
        }
    }
}
