﻿using System;
using Android.Runtime;
using NightMates.Business.ExceptionHandling;
using NightMates.Domain.Interfaces.ExceptionHandling;

namespace NightMates.Mobile.Droid.ExceptionHandling
{
    public class ExceptionHandler : ExceptionHandlerBase
    {
        public ExceptionHandler(IExceptionHandlingStrategy exceptionHandlingStrategy)
            : base(exceptionHandlingStrategy)
        {
        }

        protected override void Attach()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironmentUnhandledExceptionRaiser;
        }

        protected override void Detach()
        {
            AppDomain.CurrentDomain.UnhandledException -= CurrentDomainUnhandledException;
            AndroidEnvironment.UnhandledExceptionRaiser -= AndroidEnvironmentUnhandledExceptionRaiser;
        }

        private void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception exception)
            {
                HandleException(exception);
            }
        }

        private async void AndroidEnvironmentUnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
        {
            if (e.Exception != null)
            {
                e.Handled = await HandleException(e.Exception).ConfigureAwait(false);
            }
        }
    }
}