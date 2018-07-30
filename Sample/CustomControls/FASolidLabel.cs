using Xamarin.Forms;

namespace Sample.CustomControls
{
    public class FASolidLabel : IconLabelBase
    {
        public override string FontName => Device.RuntimePlatform == Device.Android ? "fa-solid-900.ttf#FontAwesome5FreeSolid" : "FontAwesome5FreeSolid";
    }
}
