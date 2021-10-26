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

namespace KNBNDesktopUI.ViewModels
{
    public class GroupViewModel : Screen
    {
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;
        private readonly IUserEndpoint _userEndpoint;

        public GroupViewModel(StatusInfoViewModel status, IWindowManager window, IUserEndpoint userEndpoint, IGroupEndpoint groupEndpoint)
        {
            _status = status;
            _window = window;
            _userEndpoint = userEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            try
            {

            }
            catch (Exception ex)
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "System Error";

                if (ex.Message == "Unauthorized")
                {
                    _status.UpdateMessage("Unauthorized Acces", "You shall not passed!");
                    await _window.ShowDialogAsync(_status, null, settings);

                }
            }
        }

        // set op listbox
        private BindingList<string> _availableUsers = new BindingList<string>();

        private BindingList<string> _groups;        


        public BindingList<string> AvailableUsers
        {
            get { return _availableUsers; }
            set
            { 
                _availableUsers = value;
                NotifyOfPropertyChange(() => AvailableUsers);
            }
        }


        public BindingList<string> Groups
        {
            get 
            { 
                return _groups;
            }

            set 
            { 
                _groups = value;
                NotifyOfPropertyChange(() => Groups);
            }
        }


        /*
        private async Task LoadUsers()
        {
            var users = await _userEndpoint.GetAll
        }
        */

        /*
        private async Task LoadGroups()
        {
            var groupList = await _
        }
        */

    }
}
