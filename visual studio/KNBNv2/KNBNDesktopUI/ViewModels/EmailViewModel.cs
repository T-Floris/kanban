using Caliburn.Micro;
using KNBNDesktopUI.Library.Api;
using KNBNDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.ViewModels
{
    public class EmailViewModel : Screen
    {
        private IAPIHelper _apiHelper;
        private IEventAggregator _events;
        private IUserEndpoint _userEndpoint;
        private ILoggedInUserModel _loggedInUser;

        public EmailViewModel(IAPIHelper apiHelper, IEventAggregator events, IUserEndpoint userEndpoint, ILoggedInUserModel loggedInUser)
        {
            _apiHelper = apiHelper;
            _events = events;
            _userEndpoint = userEndpoint;
            _loggedInUser = loggedInUser;
        }



        public ILoggedInUserModel LoggedInUser
        {
            get { return _loggedInUser; }
            set { _loggedInUser = value; }
        }


        private string _NewEmail;

        public string NewEmail
        {
            get { return _NewEmail; }
            set 
            { 
                _NewEmail = value;
                NotifyOfPropertyChange(() => NewEmail);
            }
        }

        public bool IsErrorVisible
        {
            get
            {
                bool output = false;

                if (ErrorMessage?.Length > 0)
                {
                    output = true;
                }

                return output;
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }

        public async Task UpdateEmail()
        {
            ErrorMessage = "";

            UpdateEmailModel email = new()
            {
                NewEmail = NewEmail,
                Token = LoggedInUser.Token
            };

            try
            {
                await _userEndpoint.UpdateEmail(email);

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }

    }
}
