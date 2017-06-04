using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBV
{
    public class customer
    {
        public Address address { get; set; }
        public string customerName { get; set; }
        public int customerID { get; set; }
    }

    public class Address
    {
        public string doorNumber { get; set; }
        public string buildingName { get; set; }
        public string streetNumber { get; set; }
        public string streetName { get; set; }
        public string addressLine2 { get; set; }
        public string addressLine3 { get; set; }
        public string town { get; set; }
        public string region { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
    }
}
