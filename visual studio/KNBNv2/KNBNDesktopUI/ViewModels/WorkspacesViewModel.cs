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
        private readonly IBoardEndpoint _boardEndpoint;
        private IAPIHelper _apiHelper;
        private IEventAggregator _events;

        public WorkspacesViewModel(StatusInfoViewModel status, IWindowManager window, IUserEndpoint userEndpoint, IAPIHelper helper, IEventAggregator @event, IBoardEndpoint boardEndpoint)
        {
            _status = status;
            _window = window;
            _userEndpoint = userEndpoint;
            _apiHelper = helper;
            _events = @event;
            _boardEndpoint = boardEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            try
            {
                await LoadWorkspaces();

            }
            catch (Exception ex)
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "System Error";

                switch (ex.Message)
                {
                    case "Unauthorized":
                        _status.UpdateMessage("Unauthorized Acces", "You shall not passed!");
                        await _window.ShowDialogAsync(_status, null, settings);
                        break;

                    case "Internal Server Error":
                        _status.UpdateMessage("Internal Server Error", "You shall not passed!");
                        await _window.ShowDialogAsync(_status, null, settings);
                        break; 

                    default:
                        break;
                }
            }
        }


        private async Task LoadWorkspaces()
        {
            var boarderList = await _boardEndpoint.GetAll();
            Board = new BindingList<BoardModel>(boarderList);
        }
        
         


        // load all users workspace
        private BindingList<BoardModel> _board;

        public BindingList<BoardModel> Board
        {
            get { return _board; }
            set 
            { 
                _board = value;
                NotifyOfPropertyChange(() => Board);
            }
        } 



    }
}


