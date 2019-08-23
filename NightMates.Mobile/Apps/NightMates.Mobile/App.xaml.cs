using NightMates.Common.Utils;
using NightMates.DataAccess;
using NightMates.Mobile.Navigation;
using Prism;
using Prism.Ioc;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NightMates.Mobile
{
    public partial class App
    {
        public App(IPlatformInitializer platformInitializer)
            : base(platformInitializer)
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            InitializeStorage();

            NavigationService.NavigateAsync($"/{Pages.Login}");
        }

        private void InitializeStorage()
        {
            AsyncHelper.RunSync(() => Container.Resolve<IStorageInitializer>().InitializeAsync());
        }
    }
}
