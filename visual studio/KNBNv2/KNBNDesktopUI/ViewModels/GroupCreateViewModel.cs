using Caliburn.Micro;
using KNBNDesktopUI.EventModels;
using KNBNDesktopUI.Library.Api;
using KNBNDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KNBNDesktopUI.ViewModels
{
    public class GroupCreateViewModel : Screen
    {
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;
        private readonly IUserEndpoint _userEndpoint;
        private readonly IGroupEndpoint _groupEndpoint;
        private IEventAggregator _events;
        public GroupCreateViewModel(StatusInfoViewModel status, IWindowManager window, IUserEndpoint userEndpoint, IGroupEndpoint groupEndpoint, IEventAggregator events)
        {
            _status = status;
            _window = window;
            _userEndpoint = userEndpoint;
            _groupEndpoint = groupEndpoint;
            _events = events;
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

        private string _color;

        public string Color
        {
            get { return _color; }
            set
            { 
                _color = value;
                NotifyOfPropertyChange(() => Color);
            }
        }

        public async Task CreateGroup()
        {

            CreateGroupModel group = new()
            {
                Name = GroupName,
                Color = Color
            };

            try
            {
                await _groupEndpoint.CreateGroup(group);
                await _events.PublishOnUIThreadAsync(new GroupEvent(), new CancellationToken());
            }
            catch (Exception)
            {

                throw;
            }
            


        }



    }
}
