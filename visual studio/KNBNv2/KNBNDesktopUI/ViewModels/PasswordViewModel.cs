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
    public class PasswordViewModel : Screen
    {
        private IAPIHelper _apiHelper;
        private IEventAggregator _events;
        private IUserEndpoint _userEndpoint;
        private ILoggedInUserModel _user;

        private string _OldPassword;
        private string _NewPassword;
        private string _PasswordRepeat;

        public PasswordViewModel(IAPIHelper apiHelper, IEventAggregator events, IUserEndpoint userEndpoint, ILoggedInUserModel user)
        {
            _apiHelper = apiHelper;
            _events = events;
            _userEndpoint = userEndpoint;
            _user = user;
        }


        public string currentPassword
        {
            get { return _OldPassword; }
            set { _OldPassword = value; }
        }

        public string NewPassword
        {
            get { return _NewPassword; }
            set { _NewPassword = value; }
        }

        public string PasswordRepeat
        {
            get { return _PasswordRepeat; }
            set { _PasswordRepeat = value; }
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


        public async Task UpdatePassword()
        {
            ErrorMessage = "";

            UpdatePasswordModel password = new()
            {
                currentPassword = currentPassword,
                NewPassword = NewPassword,
                PasswordRepeat = PasswordRepeat

            };

            try
            {
                await _userEndpoint.UpdatePassword(password);              

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

    }
}
