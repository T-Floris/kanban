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

        public ShellViewModel(IEventAggregator events, ILoggedInUserModel user, IAPIHelper apiHelper)
        {
            _events = events;
            _user = user;
            _apiHelper = apiHelper;

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

        public void ExitApplication()
        {
            TryCloseAsync();
        }

        public async Task LogIn()
        {
            await ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());

            await ChangeActiveItemAsync(IoC.Get<LoginViewModel>(), true, new CancellationToken());
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

        public async Task UserManagement()
        {
            await ActivateItemAsync(IoC.Get<UserDisplayViewModel>(), new CancellationToken());
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
            string eventName = ob.GetType().ToString().Trim().Replace("Event", "").Replace("KNBNDesktopUI.Models.", "");

            switch (eventName)
            {
                case "Register":
                    await ActivateItemAsync(IoC.Get<RegisterViewModel>(), cancellationToken);
                    NotifyOfPropertyChange(() => IsLoggedIn);
                    NotifyOfPropertyChange(() => IsLoggedOut);
                    break;

                case "LogOn":
                    await ActivateItemAsync(IoC.Get<UserDisplayViewModel>(), cancellationToken);
                    NotifyOfPropertyChange(() => IsLoggedIn);
                    NotifyOfPropertyChange(() => IsLoggedOut);
                    break;

                default:
                    break;
            }
        }
    }
}
