using Caliburn.Micro;
using RMDesktopUI.EventModels;
using System.Threading;
using System.Threading.Tasks;

namespace RMDesktopUI.ViewModels
{
    public class ShellViewModel: Conductor<object>,IHandle<LogOnEvent>
    {
        private SalesViewModel _salesViewModel;
        private SimpleContainer _container;
        private IEventAggregator _events;
        public ShellViewModel(SimpleContainer container, IEventAggregator events, SalesViewModel salesViewModel)
        {
            _events = events;
            _container = container;
            _salesViewModel = salesViewModel;

            _events.SubscribeOnPublishedThread(this);
            ActivateItemAsync(_container.GetInstance<LoginViewModel>());
        }

        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_salesViewModel);
        }
    }
}
