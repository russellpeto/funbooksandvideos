using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FBV.Objects
{
    public class PurchaseOrder
    {
        [Key]
        public int purchaseOrderID { get; set; }
        public DateTime timeOrderPlaced { get; set; }
        public List<OrderItem> items { get; set; }
    }
}
