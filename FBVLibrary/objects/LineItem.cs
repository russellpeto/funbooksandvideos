using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FBV.Enums;

namespace FBV.Objects
{
    public class LineItem
    {
        [Key]
        public int lineItemID { get; set; }
        public int orderItemID { get; set; }

        public string shortDescription { get; set; }
        public string fullDescription { get; set; }
        public decimal unitPrice { get; set; }
        public OrderItemType orderItemType { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
