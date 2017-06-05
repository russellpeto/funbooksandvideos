using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FBV.Enums;

namespace FBV.Objects
{
    public class PurchaseOrder
    {
        [Key]
        public int purchaseOrderID { get; set; }
        public int customerID { get; set; }
        public DateTime timeOrderPlaced { get; set; }
        public PurchaseOrderStatus purchaseOrderStatus { get; set; }
        public List<LineItems> purchaseOrderItems { get; set; }
        public decimal totalPrice
        {
            get
            {
                decimal total = 0;
                foreach(LineItems p in purchaseOrderItems)
                {
                    total += p.unitPrice;
                }
                return total;
            }
        }
    }
}
