using Xamarin.Forms;

namespace Sample.CustomControls
{
    public abstract class IconLabelBase : Label
    {
        public abstract string FontName { get; }

        public IconLabelBase()
        {
            FontFamily = FontName;
        }
    }
}
