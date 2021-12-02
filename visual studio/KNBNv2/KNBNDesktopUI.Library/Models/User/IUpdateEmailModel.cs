using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.Library.Models
{
    public interface IUpdateEmailModel
    {
        public string CurrentEmail { get; set; }
        public string NewEmail { get; set; }
        public string Token { get; set; }
        void ResetEmailModel();
    }
}
