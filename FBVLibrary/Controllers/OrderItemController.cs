using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBV.Objects;
using FBV.Enums;

namespace FBV.Controllers
{
    public class OrderItemController
    {
        public OrderItem CreateOrderItem()
        {
            using (var db = new FBV.FBVDatabaseContext())
            {
                OrderItem newOrderItem = db.OrderItems.Create();
                db.OrderItems.Add(newOrderItem);

                db.SaveChanges();

                return newOrderItem;
            }
        }
        public OrderItem CreateOrderItem(OrderItem newOrderItem)
        {
            using (var db = new FBV.FBVDatabaseContext())
            {
                db.OrderItems.Add(newOrderItem);

                db.SaveChanges();

                return newOrderItem;
            }
        }
        public void DeleteOrderItem(OrderItem orderItem)
        {
            using (var db = new FBV.FBVDatabaseContext())
            {
                OrderItem orderItemToDelete = db.OrderItems.Find(orderItem.orderItemID);
                db.OrderItems.Remove(orderItemToDelete);

                db.SaveChanges();
            }
        }

        public OrderItem lookupOrderItem(int orderItemID)
        {
            using (var db = new FBV.FBVDatabaseContext())
            {
                try
                {
                    return db.OrderItems.Find(orderItemID);
                }
                catch
                {
                    throw new Exception("No order item found with specified ID");
                }
            }
        }
        public OrderItem lookupOrderItem(string orderItemShortDescription)
        {
            using (var db = new FBV.FBVDatabaseContext())
            {
                try
                {
                    return db.OrderItems.SingleOrDefault(x => x.shortDescription == orderItemShortDescription);
                }
                catch
                {
                    throw new Exception("No order item found with specified description");
                }
            }
        }
    }
}
