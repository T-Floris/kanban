using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.Library.Models
{
    public interface ICreateUserModel
    {
        //string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string EmailAddress { get; set; }
        string UserName { get; set; }
        DateTime CreateDate { get; set; }
    }
}
