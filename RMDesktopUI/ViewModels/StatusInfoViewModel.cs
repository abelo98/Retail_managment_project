using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.ViewModels
{
    public class StatusInfoViewModel : Screen
    {
        public string Message { get; private set; }
        public string Header { get; private set; }

        public void UpdateMessage(string message, string header)
        {
            Message = message;
            Header = header;

            NotifyOfPropertyChange(() => Message);
            NotifyOfPropertyChange(() => Header);
        }

        public void Close()
        {
            TryCloseAsync();
        }
    }
}
