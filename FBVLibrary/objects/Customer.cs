using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FBV.objects
{
    public class Customer
    {
        public int customerID { get; set; }
        public string customerName { get; set; }
        public Address address { get; set; }
    }
}
