using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.Library.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Email { get; set; }


        public string FirstName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public string EmailAddress
        {
            get; set;
        }
        public string UserName
        {
            get; set;
        }
        public DateTime CreatedDate
        {
            get; set;
        }
        public Dictionary<string, string> Roles { get; set; } = new Dictionary<string, string>();

        public string RoleList
        {
            get
            {
                return string.Join(", ", Roles.Select(x => x.Value));
            }
        }
    }
}
