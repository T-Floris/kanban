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
    public class ShellViewModel : Conductor<object>, IHandle<object>
    {
        private IEventAggregator _events;
        private ILoggedInUserModel _user;
        private IAPIHelper _apiHelper;
        private readonly IUserEndpoint _userEndpoint;


        public ShellViewModel(IEventAggregator events, ILoggedInUserModel user, IAPIHelper apiHelper, IUserEndpoint userEndpoint)
        {
            _events = events;
            _user = user;
            _apiHelper = apiHelper;
            _userEndpoint = userEndpoint;


            _events.SubscribeOnPublishedThread(this);

            // We didnt use DI here because we would once LoginView to be new instance 
            // and not having previous data inserted
            ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());
        }

        public bool IsLoggedIn
        {
            get
            {
                bool output = false;

                if (string.IsNullOrWhiteSpace(_user.Token) == false)
                {
                    output = true;
                }

                return output;
            }
        }

        public bool IsLoggedOut
        {
            get
            {
                return !IsLoggedIn;
            }
        }

        public bool IsAdmin
        {
            get
            {
                bool output = false;

                if (string.IsNullOrWhiteSpace(_user.Token) == false)
                {
                    output = true;
                }

                return output;
            }
        }




        /* File */
        public void ExitApplication()
        {
            TryCloseAsync();
        }


        /* Account */
        public async Task LogIn()
        {
            await ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());

            await ChangeActiveItemAsync(IoC.Get<LoginViewModel>(), true, new CancellationToken());
            NotifyOfPropertyChange(() => IsLoggedIn);
            NotifyOfPropertyChange(() => IsLoggedOut);
        }

        public async Task LogOut()
        {
            _user.ResetUserModel();
            _apiHelper.LogOffUser();
            //Set UI to login page
            await ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());
            NotifyOfPropertyChange(() => IsLoggedIn);
            NotifyOfPropertyChange(() => IsLoggedOut);
        }

        public async Task Register()
        {
            await ActivateItemAsync(IoC.Get<RegisterViewModel>(), new CancellationToken());
            NotifyOfPropertyChange(() => IsLoggedIn);
            NotifyOfPropertyChange(() => IsLoggedOut);
        }


        /* user */
        public async Task UserManagement()
        {
            await ActivateItemAsync(IoC.Get<UserDisplayViewModel>(), new CancellationToken());
            NotifyOfPropertyChange(() => IsLoggedIn);
            NotifyOfPropertyChange(() => IsLoggedOut);
        }

        public async Task UserProfile()
        {
            await ActivateItemAsync(IoC.Get<UserProfileViewModel>(), new CancellationToken());
            NotifyOfPropertyChange(() => IsLoggedIn);
            NotifyOfPropertyChange(() => IsLoggedOut);
        }


        /* Workspaces */
        public async Task Workspaces()
        {
            await ActivateItemAsync(IoC.Get<GroupViewModel>(), new CancellationToken());
            NotifyOfPropertyChange(() => IsLoggedIn);
            NotifyOfPropertyChange(() => IsLoggedOut);
        }



        /* Group */
        public async Task GroupManagement()
        {
            await ActivateItemAsync(IoC.Get<GroupViewModel>(), new CancellationToken());
            NotifyOfPropertyChange(() => IsLoggedIn);
            NotifyOfPropertyChange(() => IsLoggedOut);
        }

        public async Task CreateGroup()
        {
            await ActivateItemAsync(IoC.Get<GroupCreateViewModel>(), new CancellationToken());
            NotifyOfPropertyChange(() => IsLoggedIn);
            NotifyOfPropertyChange(() => IsLoggedOut);
        }

        /*
        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {

            await ActivateItemAsync(IoC.Get<RegisterViewModel>(), cancellationToken);
            NotifyOfPropertyChange(() => IsLoggedIn);
            NotifyOfPropertyChange(() => IsLoggedOut);
        }
        public Task HandleAsync(EventHandler message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        */

        public async Task HandleAsync(object ob, CancellationToken cancellationToken)
        {
            string eventName = ob.GetType().ToString().Trim().Replace("KNBNDesktopUI.EventModels.", "").Replace("Event", "");
            string t = ob.ToString();

            switch (eventName)
            {
                case "Register":
                    await ActivateItemAsync(IoC.Get<RegisterViewModel>(), cancellationToken);
                    break;

                case "LogOn":
                    await ActivateItemAsync(IoC.Get<UserProfileViewModel>(), cancellationToken);
                    break;
               
                case "Password":
                    await ActivateItemAsync(IoC.Get<PasswordViewModel>(), cancellationToken);
                    break;

                case "Email":
                    await ActivateItemAsync(IoC.Get<EmailViewModel>(), cancellationToken);
                    break;

                case "UserName":
                    await ActivateItemAsync(IoC.Get<UserNameViewModel>(), cancellationToken);

                    break;
                case "Group":
                    await ActivateItemAsync(IoC.Get<GroupViewModel>(), cancellationToken);
                    break;

                default:
                    break;
            }

            NotifyOfPropertyChange(() => IsLoggedIn);
            NotifyOfPropertyChange(() => IsLoggedOut);
        }
    }
}
