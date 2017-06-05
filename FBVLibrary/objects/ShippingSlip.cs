using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FBV.Objects
{
    public class ShippingSlip
    {
        [Key]
        public int shippingSlipID { get; set; }
        public string shippingName { get; set; }
        public Address shippingAddress { get; set; }
        public int purchaseOrderID { get; set; }
    }
}
