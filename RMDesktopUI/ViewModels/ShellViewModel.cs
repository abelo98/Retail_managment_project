using Caliburn.Micro;
using RMDesktopUI.EventModels;
using System.Threading;
using System.Threading.Tasks;

namespace RMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private SalesViewModel _salesViewModel;

        private IEventAggregator _events;
        public ShellViewModel(IEventAggregator events, SalesViewModel salesViewModel)
        {
            _events = events;
            _salesViewModel = salesViewModel;

            _events.SubscribeOnPublishedThread(this);
            ActivateItemAsync(IoC.Get<LoginViewModel>());
        }

        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_salesViewModel);
        }
    }
}
