using Android.Content;
using Android.Graphics;
using NightMates.Mobile.Droid.Renderers;
using NightMates.Mobile.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Editor), typeof(NightMatesEditorRenderer))]
namespace NightMates.Mobile.Droid.Renderers
{
    public class NightMatesEditorRenderer : EditorRenderer
    {
        public NightMatesEditorRenderer(Context context)
            : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var customColor = ColorPalette.EditorBorder;
                Control.Background.SetColorFilter(customColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
            }
        }
    }
}