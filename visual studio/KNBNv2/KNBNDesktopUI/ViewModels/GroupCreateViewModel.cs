using Caliburn.Micro;
using KNBNDesktopUI.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.ViewModels
{
    public class GroupCreateViewModel : Screen
    {
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;
        private readonly IUserEndpoint _userEndpoint;
        private readonly IGroupEndpoint _groupEndpoint;
        public GroupCreateViewModel(StatusInfoViewModel status, IWindowManager window, IUserEndpoint userEndpoint, IGroupEndpoint groupEndpoint)
        {
            _status = status;
            _window = window;
            _userEndpoint = userEndpoint;
            _groupEndpoint = groupEndpoint;
        }

        private string _groupName;

        public string GroupName
        {
            get { return _groupName; }
            set 
            { 
                _groupName = value;
                NotifyOfPropertyChange(() => GroupName);
            }
        }


    }
}
