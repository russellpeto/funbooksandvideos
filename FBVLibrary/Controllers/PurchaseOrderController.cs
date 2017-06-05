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
    class PurchaseOrderController
    {
        public PurchaseOrder NewPurchaseOrder(Customer thisCustomer)
        {
            using(var db = new FBVDatabaseContext())
            {
                PurchaseOrder createdPurchaseOrder = db.PurchaseOrders.Create();
                createdPurchaseOrder.customerID = thisCustomer.customerID;

                return createdPurchaseOrder;
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

        /// <summary>
        /// Checks to see if there is a membership in the purchase order, if so, immediately implements it in the DB
        /// </summary>
        /// <param name="thisPurchaseOrder"></param>
        private void implementMembership(PurchaseOrder thisPurchaseOrder)
        {
            using (var db = new FBVDatabaseContext())
            {
                foreach(LineItems i in thisPurchaseOrder.purchaseOrderItems)
                {
                    MembershipEntry newMembership = db.MembershipEntries.Create();
                    switch (i.orderItemType)
                    {
                        case OrderItemType.BookClub:
                            newMembership.bookClubMembership = true;
                            break;
                        case OrderItemType.PremiumClub:
                            newMembership.bookClubMembership = true;
                            newMembership.videoClubMembership = true;
                            break;
                        case OrderItemType.VideoClub:
                            newMembership.videoClubMembership = true;
                            break;
                        default:
                            break;
                    }
                    newMembership.customerID = thisPurchaseOrder.customerID;
                    newMembership.expiryDate = DateTime.Now.AddYears(1);
                    newMembership.lineItemID = i.lineItemID;
                    db.MembershipEntries.Add(newMembership);
                }
            }
        }
    }
}
