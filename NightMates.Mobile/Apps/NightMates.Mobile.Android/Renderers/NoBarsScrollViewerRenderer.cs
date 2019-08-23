using System;
using System.ComponentModel;
using Android.Content;
using NightMates.Mobile.Controls;
using NightMates.Mobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NoBarsScrollViewer), typeof(NoBarsScrollViewerRenderer))]
namespace NightMates.Mobile.Droid.Renderers
{
    public class NoBarsScrollViewerRenderer : ScrollViewRenderer
    {
        public NoBarsScrollViewerRenderer(Context context)
            : base(context)
        {
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            if (e.OldElement != null)
            {
                e.OldElement.PropertyChanged -= OnElementPropertyChanged;
            }

            e.NewElement.PropertyChanged += OnElementPropertyChanged;
        }

        private void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (string.Equals(e.PropertyName, "ContentSize", StringComparison.Ordinal) && ChildCount > 0)
            {
                var child = GetChildAt(0);
                child.VerticalScrollBarEnabled = false;
                child.HorizontalScrollBarEnabled = false;
            }
        }
    }
}