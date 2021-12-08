using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.Library.Models
{
    public class BoardModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BoardId { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

    }
}
