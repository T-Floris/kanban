using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KNBNDesktopUI.EventModels;
using KNBNDesktopUI.Library.Api;

namespace KNBNDesktopUI.ViewModels
{
    class UserProfileViewModel : Screen
    {
        private IAPIHelper _apiHelper;
        private IEventAggregator _events;
        private IUserEndpoint _userEndpoint;

        public UserProfileViewModel(IAPIHelper apiHelper, IEventAggregator events, IUserEndpoint userEndpoint)
        {
            _apiHelper = apiHelper;
            _events = events;
            _userEndpoint = userEndpoint;
        }


        private string _Id;
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _UserName;

        public string Id
        {
            get { return _Id; }
            set 
            { 
                _Id = value;
                NotifyOfPropertyChange(() => Id);

            }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set 
            { 
                _FirstName = value;
                NotifyOfPropertyChange(() => FirstName);

            }
        }
        public string LastName
        {
            get { return _LastName; }
            set 
            { 
                _LastName = value;
                NotifyOfPropertyChange(() => LastName);

            }
        }
        public string Email
        {
            get { return _Email; }
            set 
            { 
                _Email = value;
                NotifyOfPropertyChange(() => Email);

            }
        }
        public string UserName
        {
            get { return _UserName; }
            set 
            { 
                _UserName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }

        // change password



        // Edit email

        public async Task chPassword()
        {
            try
            {
                await _events.PublishOnUIThreadAsync(new PasswordEvent(), new CancellationToken());

            }
            catch (Exception)
            {

            }
        }

        public async Task chEmail()
        {
            try
            {
                await _events.PublishOnUIThreadAsync(new EmailEvent(), new CancellationToken());

            }
            catch (Exception)
            {

            }
        }

        public async Task chUserName()
        {
            try
            {
                await _events.PublishOnUIThreadAsync(new UserNameEvent(), new CancellationToken());

            }
            catch (Exception)
            {

            }
        }
    }



}

