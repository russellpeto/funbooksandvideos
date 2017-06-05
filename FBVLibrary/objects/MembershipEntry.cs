using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FBV.Objects
{
    public class MembershipEntry
    {
        [Key]
        public int MembershipEntryID { get; set; }
        public int customerID { get; set; }
        public int lineItemID { get; set; }
        public DateTime expiryDate { get; set; }
        public bool bookClubMembership { get; set; }
        public bool videoClubMembership { get; set; }
    }
}
