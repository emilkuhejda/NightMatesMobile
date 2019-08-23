using System;
using NightMates.Logging.Interfaces;

namespace NightMates.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(ILoggerFactory loggerFactory)
            : base(loggerFactory)
        {
            throw new ArgumentException(nameof(loggerFactory));
        }
    }
}
