﻿using System.Threading.Tasks;
using NightMates.Mobile.Utils;
using Prism.Navigation;

namespace NightMates.Mobile.Extensions
{
    public static class NavigationServiceExtensions
    {
        public static async Task NavigateWithoutAnimationAsync(this INavigationService navigationService, string name, INavigationParameters parameters = null)
        {
            await ThreadHelper.InvokeOnUiThread(() => navigationService.NavigateAsync(name, parameters, null, false).ConfigureAwait(false));
        }

        public static async Task GoBackWithoutAnimationAsync(this INavigationService navigationService, INavigationParameters parameters = null)
        {
            await ThreadHelper.InvokeOnUiThread(() => navigationService.GoBackAsync(parameters, null, false).ConfigureAwait(false));
        }
    }
}
