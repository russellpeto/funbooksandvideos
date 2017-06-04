using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBV.objects
{
    class Membership : OrderItem
    {
        public MembershipTypes type { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
