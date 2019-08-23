using System;
using System.ComponentModel;
using NightMates.Mobile.Controls;
using NightMates.Mobile.UWP.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using ScrollBarVisibility = Windows.UI.Xaml.Controls.ScrollBarVisibility;

[assembly: ExportRenderer(typeof(NoBarsScrollViewer), typeof(NoBarsScrollViewerRenderer))]
namespace NightMates.Mobile.UWP.Renderers
{
    public class NoBarsScrollViewerRenderer : ScrollViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ScrollView> e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            if (e.OldElement != null)
                e.OldElement.PropertyChanged -= OnPropertyChanged;

            e.NewElement.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (string.Equals(e.PropertyName, "ContentSize", StringComparison.Ordinal))
            {
                var scrollViewer = Control;
                scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            }
        }
    }
}
