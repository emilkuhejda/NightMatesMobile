using System;

namespace NightMates.Domain.Interfaces.ExceptionHandling
{
    public interface IExceptionHandlingStrategy
    {
        bool HandleException(Exception exception);
    }
}
