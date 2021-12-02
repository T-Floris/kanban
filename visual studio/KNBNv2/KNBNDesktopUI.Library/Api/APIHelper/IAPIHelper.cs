using KNBNDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);


        Task GetLoginUserInfo(string token);

        void LogOffUser();

        Task CreateUser(string FirstName, string LastName, string Email, string UserName, string Password, string Password_repeat);

        HttpClient ApiClient { get; }
    }
}
