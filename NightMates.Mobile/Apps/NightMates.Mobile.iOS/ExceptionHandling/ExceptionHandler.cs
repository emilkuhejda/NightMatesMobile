using System;
using System.Runtime.InteropServices;
using NightMates.Business.ExceptionHandling;
using NightMates.Domain.Interfaces.ExceptionHandling;

namespace NightMates.Mobile.iOS.ExceptionHandling
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

            AttachToNativeExceptions();
        }

        private void AttachToNativeExceptions()
        {
            IntPtr sigbus = Marshal.AllocHGlobal(512);
            IntPtr sigsegv = Marshal.AllocHGlobal(512);

            // Store Mono SIGSEGV and SIGBUS handlers
            NativeMethods.sigaction(NativeMethods.Signal.SIGBUS, IntPtr.Zero, sigbus);
            NativeMethods.sigaction(NativeMethods.Signal.SIGSEGV, IntPtr.Zero, sigsegv);

            // Restore Mono SIGSEGV and SIGBUS handlers
            NativeMethods.sigaction(NativeMethods.Signal.SIGBUS, sigbus, IntPtr.Zero);
            NativeMethods.sigaction(NativeMethods.Signal.SIGSEGV, sigsegv, IntPtr.Zero);

            Marshal.FreeHGlobal(sigbus);
            Marshal.FreeHGlobal(sigsegv);
        }

        protected override void Detach()
        {
            AppDomain.CurrentDomain.UnhandledException -= CurrentDomainUnhandledException;
        }

        private void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception exception)
            {
                HandleException(exception);
            }
        }
    }
}