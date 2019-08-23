using System.Threading.Tasks;
using NightMates.DataAccess.Entities;
using NightMates.DataAccess.Providers;

namespace NightMates.DataAccess
{
    public class StorageInitializer : IStorageInitializer
    {
        private const int DatabaseVersionNumber = 0;

        private readonly IAppDbContextProvider _contextProvider;

        public StorageInitializer(IAppDbContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public async Task InitializeAsync()
        {
            var tables = new[]
            {
                typeof(InternalValueEntity)
            };

            var versionNumber = await _contextProvider.Context.GetVersionNumberAsync().ConfigureAwait(false);
            if (versionNumber < DatabaseVersionNumber)
            {
                foreach (var table in tables)
                {
                    await _contextProvider.Context.DropTable(table).ConfigureAwait(false);
                }

                await _contextProvider.Context.UpdateVersionNumberAsync(DatabaseVersionNumber).ConfigureAwait(false);
            }

            await _contextProvider.Context.CreateTablesAsync(tables).ConfigureAwait(false);
        }
    }
}
