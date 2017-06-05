using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBV;
using FBV.Objects;
using FBV.Enums;

namespace FBV.Controllers
{
    public class PurchaseOrderController
    {
        public PurchaseOrder NewPurchaseOrder(Customer thisCustomer)
        {
            using(var db = new FBVDatabaseContext())
            {
                PurchaseOrder createdPurchaseOrder = db.PurchaseOrders.Create();
                createdPurchaseOrder.customerID = thisCustomer.customerID;
                createdPurchaseOrder.purchaseOrderStatus = PurchaseOrderStatus.notYetOrdered;
                db.PurchaseOrders.Add(createdPurchaseOrder);
                db.SaveChanges();

                return createdPurchaseOrder;
            }
        }
        public PurchaseOrder NewPurchaseOrder(PurchaseOrder newPurchaseOrder)
        {
            using (var db = new FBVDatabaseContext())
            {
                db.PurchaseOrders.Add(newPurchaseOrder);
                db.SaveChanges();

                return newPurchaseOrder;
            }
        }

        public PurchaseOrder UpdatePurchaseOrder(PurchaseOrder thisPurchaseOrder)
        {
            using (var db = new FBVDatabaseContext())
            {
                PurchaseOrder existingPurchaseOrder = db.PurchaseOrders.Find(thisPurchaseOrder.purchaseOrderID);
                db.Entry(existingPurchaseOrder).CurrentValues.SetValues(thisPurchaseOrder);
                db.SaveChanges();

                return existingPurchaseOrder;
            }
        }

        public PurchaseOrder commitPurchaseOrder(PurchaseOrder thisPurchaseOrder)
        {
            using (var db = new FBVDatabaseContext())
            {
                PurchaseOrder existingPurchaseOrder = db.PurchaseOrders.Find(thisPurchaseOrder.purchaseOrderID);
                existingPurchaseOrder.purchaseOrderStatus = PurchaseOrderStatus.ordered;
                db.SaveChanges();

                implementMembership(existingPurchaseOrder);

                return existingPurchaseOrder;
            }
        }

        public PurchaseOrder addToPurchaseOrder(OrderItem orderItem, PurchaseOrder thisPurchaseOrder)
        {
            using (var db = new FBVDatabaseContext())
            {
                LineItem lineItem = new LineItem();

                lineItem.fullDescription = orderItem.fullDescription;
                lineItem.shortDescription = orderItem.shortDescription;
                lineItem.unitPrice = orderItem.unitPrice;
                lineItem.orderItemID = orderItem.orderItemID;
                lineItem.orderItemType = orderItem.orderType;
                switch (lineItem.orderItemType)
                {
                    case OrderItemType.BookClub:
                        lineItem.startDate = DateTime.Now;
                        lineItem.endDate = DateTime.Now.AddYears(1);
                        break;
                    case OrderItemType.VideoClub:
                        lineItem.startDate = DateTime.Now;
                        lineItem.endDate = DateTime.Now.AddYears(1);
                        break;
                    case OrderItemType.PremiumClub:
                        lineItem.startDate = DateTime.Now;
                        lineItem.endDate = DateTime.Now.AddYears(1);
                        break;
                    default:
                        break;
                }

                var purchaseOrderToUpdate = db.PurchaseOrders.Find(thisPurchaseOrder.purchaseOrderID);
                purchaseOrderToUpdate.purchaseOrderItems.Add(lineItem);

                db.SaveChanges();

                return purchaseOrderToUpdate;
            }
        }

        public PurchaseOrder removeFromPurchaseOrder(OrderItem orderItem, PurchaseOrder thisPurchaseOrder)
        {
            using (var db = new FBVDatabaseContext())
            {
                PurchaseOrder orderToAmend = db.PurchaseOrders.Find(thisPurchaseOrder.purchaseOrderID);

                LineItem itemToRemove = orderToAmend.purchaseOrderItems.Find(x => x.orderItemID == orderItem.orderItemID);
                orderToAmend.purchaseOrderItems.Remove(itemToRemove);

                db.SaveChanges();

                return orderToAmend;
            }
        }

        /// <summary>
        /// Checks to see if there is a membership in the purchase order, if so, immediately implements it in the DB
        /// </summary>
        /// <param name="thisPurchaseOrder"></param>
        private void implementMembership(PurchaseOrder thisPurchaseOrder)
        {
            using (var db = new FBVDatabaseContext())
            {
                foreach(LineItem i in thisPurchaseOrder.purchaseOrderItems)
                {
                    MembershipEntry newMembership = db.MembershipEntries.Create();
                    newMembership.customerID = thisPurchaseOrder.customerID;
                    newMembership.expiryDate = DateTime.Now.AddYears(1);
                    newMembership.lineItemID = i.lineItemID;
                    switch (i.orderItemType)
                    {
                        case OrderItemType.BookClub:
                            newMembership.bookClubMembership = true;
                            db.MembershipEntries.Add(newMembership);
                            db.SaveChanges();
                            break;
                        case OrderItemType.PremiumClub:
                            newMembership.bookClubMembership = true;
                            newMembership.videoClubMembership = true;
                            db.MembershipEntries.Add(newMembership);
                            db.SaveChanges();
                            break;
                        case OrderItemType.VideoClub:
                            newMembership.videoClubMembership = true;
                            db.MembershipEntries.Add(newMembership);
                            db.SaveChanges();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// checks to see if there is a physical product (IE Book, as videos are watched online) and if so
        /// generates a shipping slip entry
        /// </summary>
        /// <param name="thisPurchaseOrder"></param>
        private void checkShipping(PurchaseOrder thisPurchaseOrder)
        {
            using (var db = new FBVDatabaseContext())
            {
                bool needsShipping = false;
                foreach(LineItem i in thisPurchaseOrder.purchaseOrderItems)
                {
                    if(i.orderItemType == OrderItemType.Book)
                    {
                        needsShipping = true;
                    }
                }

                if (needsShipping)
                {
                    Customer thisCustomer = db.Customers.Find(thisPurchaseOrder.customerID);
                    ShippingSlip newSlip = db.ShippingSlips.Create();
                    newSlip.purchaseOrderID = thisPurchaseOrder.purchaseOrderID;
                    newSlip.shippingAddress = thisCustomer.address;
                    newSlip.shippingName = thisCustomer.customerName;

                    db.ShippingSlips.Add(newSlip);
                    db.SaveChanges();
                }
            }
        }
    }
}
