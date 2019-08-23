using System.Threading.Tasks;
using System.Windows.Input;

namespace NightMates.Mobile.Commands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();

        void ChangeCanExecute();
    }
}
