using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FBV.Enums;

namespace FBV.Objects
{
    public class OrderItem
    {
        [Key]
        public int orderItemID { get; set; }
        public string shortDescription { get; set; }
        public string fullDescription { get; set; }
        public decimal unitPrice { get; set; }
        public OrderItemType orderType { get; set; }
    }
}
