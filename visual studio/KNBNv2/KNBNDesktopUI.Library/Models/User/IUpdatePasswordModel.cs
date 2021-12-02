using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.Library.Models
{
    public interface IUpdatePasswordModel
    {
        public string currentPassword { get; set; }
        public string NewPassword { get; set; }
        public string PasswordRepeat { get; set; }
        void ResetPasswordModel();
    }
}
