using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.Library.Models
{
    public class UpdateEmailModel : IUpdateEmailModel
    {
        public string NewEmail { get; set; }
        public string Token { get; set; }
        public string CurrentEmail { get; set; }

        public void ResetEmailModel()
        {
            CurrentEmail = "";
            NewEmail = "";
            Token = "";
        }
    }
}
