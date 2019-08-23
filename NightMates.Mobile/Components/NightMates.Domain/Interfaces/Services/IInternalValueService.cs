﻿using System.Threading.Tasks;
using NightMates.Domain.Configuration;

namespace NightMates.Domain.Interfaces.Services
{
    public interface IInternalValueService
    {
        Task<T> GetValueAsync<T>(InternalValue<T> internalValue);

        Task UpdateValueAsync<T>(InternalValue<T> internalValue, T value);
    }
}
