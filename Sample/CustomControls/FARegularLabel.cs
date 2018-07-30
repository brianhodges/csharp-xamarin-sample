using Xamarin.Forms;

namespace Sample.CustomControls
{
    public class FARegularLabel : IconLabelBase
    {
        public override string FontName => Device.RuntimePlatform == Device.Android ? "fa-regular-400.ttf#FontAwesome5FreeRegular" : "FontAwesome5FreeRegular";
    }
}
