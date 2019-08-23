using System;
using System.Threading.Tasks;

namespace NightMates.Domain.Interfaces.ExceptionHandling
{
    public interface IExceptionHandlingStrategy
    {
        Task<bool> HandleException(Exception exception);
    }
}
