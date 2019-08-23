using CoreAnimation;
using CoreGraphics;
using NightMates.Mobile.iOS.Renderers;
using NightMates.Mobile.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Editor), typeof(NightMatesEditorRenderer))]
namespace NightMates.Mobile.iOS.Renderers
{
    public class NightMatesEditorRenderer : EditorRenderer
    {
        private int _sublayerNumber;

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                using (var borderLayer = new CALayer())
                {
                    Control.Layer.AddSublayer(borderLayer);

                    _sublayerNumber = Control.Layer.Sublayers.Length - 1;
                }
            }
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            Control.Layer.Sublayers[_sublayerNumber].MasksToBounds = true;
            Control.Layer.Sublayers[_sublayerNumber].Frame = new CGRect(0, Frame.Height - 5, Frame.Width, 1);
            Control.Layer.Sublayers[_sublayerNumber].BorderColor = ColorPalette.EditorBorder.ToCGColor();
            Control.Layer.Sublayers[_sublayerNumber].BorderWidth = 1;
        }
    }
}