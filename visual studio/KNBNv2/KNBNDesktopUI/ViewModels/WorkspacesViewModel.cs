using Caliburn.Micro;
using KNBNDesktopUI.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.ViewModels
{
    public class WorkspacesViewModel : Screen
    {
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;
        private readonly IUserEndpoint _userEndpoint;
        private IAPIHelper _apiHelper;
        private IEventAggregator _events;

        public WorkspacesViewModel(StatusInfoViewModel status, IWindowManager window, IUserEndpoint userEndpoint, IAPIHelper helper, IEventAggregator @event)
        {
            _status = status;
            _window = window;
            _userEndpoint = userEndpoint;
            _apiHelper = helper;
            _events = @event;
        }

    }
}
