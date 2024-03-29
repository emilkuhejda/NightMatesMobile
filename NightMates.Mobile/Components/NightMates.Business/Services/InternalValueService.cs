﻿using System;
using System.Globalization;
using System.Threading.Tasks;
using NightMates.Domain.Configuration;
using NightMates.Domain.Interfaces.Repositories;
using NightMates.Domain.Interfaces.Services;

namespace NightMates.Business.Services
{
    public class InternalValueService : IInternalValueService
    {
        private readonly IInternalValueRepository _internalValueRepository;

        public InternalValueService(IInternalValueRepository internalValueRepository)
        {
            _internalValueRepository = internalValueRepository;
        }

        public async Task<T> GetValueAsync<T>(InternalValue<T> internalValue)
        {
            var key = internalValue.Key;
            var result = await _internalValueRepository.GetValue(key).ConfigureAwait(false);
            if (result == null)
                return internalValue.DefaultValue;

            return ParseResult(result, internalValue.DefaultValue);
        }

        private T ParseResult<T>(string value, T defaultValue)
        {
            try
            {
                var result = (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
                return result;
            }
            catch (NotSupportedException)
            {
                return defaultValue;
            }
        }

        public async Task UpdateValueAsync<T>(InternalValue<T> internalValue, T value)
        {
            var key = internalValue.Key;
            var entityValue = Convert.ToString(value, CultureInfo.InvariantCulture);

            await _internalValueRepository.UpdateValue(key, entityValue).ConfigureAwait(false);
        }
    }
}
