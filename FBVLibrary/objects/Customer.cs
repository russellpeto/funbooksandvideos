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
    }
}
