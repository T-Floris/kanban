using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNApi.Library.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        public string UserId
        {
            get; set;
        }

        public string UserName
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Color
        {
            get; set;
        }

    }
}
