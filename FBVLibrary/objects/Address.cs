using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace FBV.Objects
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }

        public string doorNumber { get; set; }
        public string buildingName { get; set; }
        public string streetNumber { get; set; }
        public string streetName { get; set; }
        public List<string> addressLines { get; set; }
        public string addressLine2 { get; set; }
        public string addressLine3 { get; set; }
        public string town { get; set; }
        public string region { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
    }
}
