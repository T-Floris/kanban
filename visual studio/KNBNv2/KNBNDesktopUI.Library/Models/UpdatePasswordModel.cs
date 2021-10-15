using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.Library.Models
{
    public class UpdatePasswordModel : IUpdatePasswordModel
    {
        public string currentPassword { get; set; }
        public string NewPassword { get; set; }
        public string PasswordRepeat { get; set; }

        public void ResetPasswordModel()
        {
            currentPassword = "";
            NewPassword = "";
            PasswordRepeat = "";
        }
    }
}
