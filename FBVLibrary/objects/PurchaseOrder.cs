using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBV.objects
{
    class PurchaseOrder
    {
        public int purchaseOrderID { get; set; }
        public DateTime timeOrderPlaced { get; set; }
        public List<OrderItem> items { get; set; }
    }
}
