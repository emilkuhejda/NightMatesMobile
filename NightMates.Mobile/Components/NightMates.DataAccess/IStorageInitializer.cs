using System.Threading.Tasks;

namespace NightMates.DataAccess
{
    public interface IStorageInitializer
    {
        Task InitializeAsync();
    }
}
