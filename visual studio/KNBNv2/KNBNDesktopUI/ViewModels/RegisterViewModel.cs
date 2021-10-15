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
    class RegisterViewModel : Screen
    {

        private IAPIHelper _apiHelper;
        private IEventAggregator _events;
        private IUserEndpoint _userEndpoint;

        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _UserName;
        private string _Password;
        private string _ConfirmPassword;

        private string _errorMessage;




        public RegisterViewModel(IAPIHelper apiHelper, IEventAggregator events, IUserEndpoint userEndpoint)
        {
            _apiHelper = apiHelper;
            _events = events;
            _userEndpoint = userEndpoint;
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
        public string Password
        {
            get { return _Password; }
            set 
            { 
                _Password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }
        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set 
            {
                _ConfirmPassword = value;
                NotifyOfPropertyChange(() => ConfirmPassword);
            }
        }



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




        public async Task Register()
        {
            ErrorMessage = "";

            CreateUserModel user = new()
            {
                FirstName = FirstName,
                LastName = LastName,
                EmailAddress = Email,
                UserName = UserName,
                Password = Password,
                ConfirmPassword = ConfirmPassword
            };

            try
            {
                await _userEndpoint.CreateUser(user);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }


        }





    }
}
