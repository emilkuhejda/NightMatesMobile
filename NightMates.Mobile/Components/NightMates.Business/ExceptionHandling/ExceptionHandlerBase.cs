﻿using System;
using System.Threading.Tasks;
using NightMates.Domain.Interfaces.ExceptionHandling;

namespace NightMates.Business.ExceptionHandling
{
    public abstract class ExceptionHandlerBase : IExceptionHandler
    {
        private readonly IExceptionHandlingStrategy _exceptionHandlingStrategy;

        protected ExceptionHandlerBase(IExceptionHandlingStrategy exceptionHandlingStrategy)
        {
            _exceptionHandlingStrategy = exceptionHandlingStrategy ?? throw new ArgumentNullException(nameof(exceptionHandlingStrategy));
        }

        public void RegisterForExceptions()
        {
            // Before attaching we want to make sure, we only have one subscription at the time
            InternalDetach();

            // Call Attach in order to wire up platform-specific crash observation
            InternalAttach();
        }

        private void InternalAttach()
        {
            Attach();

            TaskScheduler.UnobservedTaskException += OnTaskSchedulerUnobservedTaskException;
        }

        protected abstract void Attach();

        private void InternalDetach()
        {
            Detach();

            TaskScheduler.UnobservedTaskException -= OnTaskSchedulerUnobservedTaskException;
        }

        protected abstract void Detach();

        private async void OnTaskSchedulerUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            if (e.Exception != null)
            {
                var isHandled = await HandleException(e.Exception).ConfigureAwait(false);
                if (isHandled)
                {
                    e.SetObserved();
                }
            }
        }

        protected Task<bool> HandleException(Exception exception)
        {
            return _exceptionHandlingStrategy.HandleException(exception);
        }
    }
}
