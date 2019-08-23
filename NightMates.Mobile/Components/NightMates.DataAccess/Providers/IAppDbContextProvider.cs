using System.Threading.Tasks;

namespace NightMates.DataAccess.Providers
{
    public interface IAppDbContextProvider
    {
        IAppDbContext Context { get; }

        Task CloseAsync();
    }
}
