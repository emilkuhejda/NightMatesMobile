using System.Threading.Tasks;
using NightMates.DataAccess.Entities;
using NightMates.DataAccess.Providers;
using NightMates.Domain.Interfaces.Repositories;

namespace NightMates.DataAccess.Repositories
{
    public class InternalValueRepository : IInternalValueRepository
    {
        private readonly IAppDbContextProvider _contextProvider;

        public InternalValueRepository(IAppDbContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public async Task<string> GetValue(string key)
        {
            var entity = await _contextProvider.Context.InternalValues.FirstOrDefaultAsync(x => x.Key == key).ConfigureAwait(false);
            return entity?.Value;
        }

        public async Task UpdateValue(string key, string value)
        {
            var entity = await _contextProvider.Context.InternalValues.FirstOrDefaultAsync(x => x.Key == key).ConfigureAwait(false);
            if (entity == null)
            {
                entity = new InternalValueEntity { Key = key, Value = value };
                await _contextProvider.Context.InsertAsync(entity).ConfigureAwait(false);
            }
            else
            {
                entity.Value = value;
                await _contextProvider.Context.UpdateAsync(entity).ConfigureAwait(false);
            }
        }
    }
}
