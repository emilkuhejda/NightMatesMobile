﻿using System.Threading.Tasks;

namespace NightMates.Domain.Interfaces.Services
{
    public interface IDialogService
    {
        Task AlertAsync(string message, string title = null, string okText = null);

        Task<bool> ConfirmAsync(string message, string title = null, string okText = null, string cancelText = null);
    }
}
