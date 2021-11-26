using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KNBNDesktopUI.Library.Api;
using KNBNDesktopUI.Library.Models;
using KNBNDesktopUI.Views;

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

        private async Task LoadWorkspaces()
        {
            //var WorkspaceList = await 
        }


        // load all users workspace
        private BindingList<WorkspacesModel> _boards;

        public BindingList<WorkspacesModel> Boards
        {
            get { return _boards; }
            set { _boards = value; }
        }



    }
}
