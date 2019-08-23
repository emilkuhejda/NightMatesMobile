using System;
using System.Threading.Tasks;
using System.Windows.Input;
using NightMates.Common.Utils;
using NightMates.Domain.Interfaces.Services;
using NightMates.Logging.Interfaces;
using NightMates.Mobile.Commands;
using NightMates.Mobile.Extensions;
using NightMates.Mobile.Navigation;
using NightMates.Mobile.Views;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace NightMates.Mobile.ViewModels
{
    public abstract class ViewModelBase : BindableBase, INavigatedAware, IDisposable
    {
        private bool _hasTitleBar;
        private bool _canGoBack;
        private bool _disposed;

        protected ViewModelBase(
            IDialogService dialogService,
            INavigationService navigationService,
            ILoggerFactory loggerFactory)
        {
            DialogService = dialogService;
            NavigationService = navigationService;
            Logger = loggerFactory.CreateLogger(GetType());
            OperationScope = new AsyncOperationScope();

            NavigateBackCommand = new AsyncCommand(ExecuteNavigateBackCommandAsync, () => CanGoBack);
            NavigateToSettingsCommand = new AsyncCommand(ExecuteNavigateToSettingsCommandAsync);
        }

        protected IDialogService DialogService { get; }

        protected INavigationService NavigationService { get; }

        protected ILogger Logger { get; }

        public AsyncOperationScope OperationScope { get; }

        public ICommand NavigateBackCommand { get; }

        public ICommand NavigateToSettingsCommand { get; }

        public bool HasTitleBar
        {
            get => _hasTitleBar;
            protected set => SetProperty(ref _hasTitleBar, value);
        }

        public bool CanGoBack
        {
            get => _canGoBack;
            protected set => SetProperty(ref _canGoBack, value);
        }

        protected bool IsCurrent => ((NightMatesNavigationPage)Application.Current.MainPage).CurrentPage.BindingContext.GetType() == GetType();

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            await LoadDataAsync(parameters).ConfigureAwait(false);
        }

        protected virtual async Task LoadDataAsync(INavigationParameters navigationParameters)
        {
            await Task.CompletedTask.ConfigureAwait(false);
        }

        private async Task ExecuteNavigateBackCommandAsync()
        {
            await NavigationService.GoBackWithoutAnimationAsync().ConfigureAwait(false);
        }

        private async Task ExecuteNavigateToSettingsCommandAsync()
        {
            await NavigationService.NavigateWithoutAnimationAsync(Pages.Settings).ConfigureAwait(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                DisposeInternal();
            }

            _disposed = true;
        }

        protected virtual void DisposeInternal() { }
    }
}
