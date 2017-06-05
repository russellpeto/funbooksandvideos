using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace FBV.Objects
{
    public class Customer
    {
        [Key]
        public int customerID { get; set; }
        public string customerName { get; set; }
        public Address address { get; set; }
        public List<MembershipEntry> memberships
        {
            get
            {
                using (var db = new FBV.FBVDatabaseContext())
                {
                    var memberships = (from x in db.MembershipEntries
                                where x.customerID == customerID
                                select x).ToList();
                    return memberships;
                }
            }
        }
    }
}
