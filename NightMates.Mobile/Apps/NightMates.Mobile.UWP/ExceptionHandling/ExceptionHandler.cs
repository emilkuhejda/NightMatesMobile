﻿using Windows.UI.Xaml;
using NightMates.Business.ExceptionHandling;
using NightMates.Domain.Interfaces.ExceptionHandling;

namespace NightMates.Mobile.UWP.ExceptionHandling
{
    public class ExceptionHandler : ExceptionHandlerBase
    {
        public ExceptionHandler(IExceptionHandlingStrategy exceptionHandlingStrategy)
            : base(exceptionHandlingStrategy)
        {
        }

        private async void OnCurrentApplicationUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            e.Handled = await HandleException(e.Exception).ConfigureAwait(false);
        }

        protected override void Attach()
        {
            if (Application.Current != null)
            {
                Application.Current.UnhandledException += OnCurrentApplicationUnhandledException;
            }
        }

        protected override void Detach()
        {
            if (Application.Current != null)
            {
                Application.Current.UnhandledException -= OnCurrentApplicationUnhandledException;
            }
        }
    }
}