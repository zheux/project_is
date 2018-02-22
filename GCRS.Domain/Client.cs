using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public class Client:User
    {
        public List<Deal> RequestList { get; set; }
        public List<Deal> PublishList { get; set; }
    }
}
