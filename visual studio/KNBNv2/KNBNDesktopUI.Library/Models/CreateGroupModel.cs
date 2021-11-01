using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.Library.Models
{
    public class CreateGroupModel : ICreateGroupModel
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
