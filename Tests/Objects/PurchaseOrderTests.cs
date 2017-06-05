using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FBV.Controllers;
using FBV.Objects;

namespace Tests.Objects
{
    [TestFixture]
    class PurchaseOrderTests
    {
        public Customer testCustomer { get; set; }
        public List<OrderItem> testOrderItems { get; set; }

        PurchaseOrderTests()
        {
            var customerController = new CustomerController();
            Customer newCustomer = new Customer { customerName = "RPeto", address = new Address { buildingName = "Paisley Mansions", doorNumber = "Flat B", streetName = "Jubilee Street", streetNumber = "44", town = "London", country = "UK", postalCode = "WC1X 0ET" } };
            testCustomer = customerController.NewCustomer(newCustomer);

            // clear out any test order items in DB and refresh them with test data
            var orderItemController = new OrderItemController();
            List<OrderItem> newOrderItems = new List<OrderItem>
            {
                new OrderItem { fullDescription = "A riveting, page turner. Couldn't put it down", shortDescription = "Time of the Wolf", orderType = FBV.Enums.OrderItemType.Book, unitPrice = 12.99M },
                new OrderItem { fullDescription = "A charming trip down memory lane, with a bittersweet sting in the tail", shortDescription = "I Remember it Well", orderType = FBV.Enums.OrderItemType.Book, unitPrice = 6.49M },
                new OrderItem { fullDescription = "A darkly enthralling thriller from the makers of Postman Pat", shortDescription = "Going Postal", orderType = FBV.Enums.OrderItemType.Video, unitPrice = 14.99M },
                new OrderItem { fullDescription = "Read to your hearts content", shortDescription = "Book Club Membership", orderType = FBV.Enums.OrderItemType.BookClub, unitPrice = 44.99M },
                new OrderItem { fullDescription = "Watch the latest movies online", shortDescription = "Video Club Membership", orderType = FBV.Enums.OrderItemType.VideoClub, unitPrice = 54.99M },
                new OrderItem { fullDescription = "Access anything from our archives, film or print", shortDescription = "Premium Membership", orderType = FBV.Enums.OrderItemType.PremiumClub, unitPrice = 84.99M }
            };


            foreach (OrderItem o in newOrderItems)
            {
                try
                {
                    OrderItem orderItemToDelete = orderItemController.lookupOrderItem(o.shortDescription);
                    orderItemController.DeleteOrderItem(orderItemToDelete);
                }
                finally
                {
                    OrderItem newOrderItem = orderItemController.CreateOrderItem(o);
                    testOrderItems.Add(newOrderItem);
                }
            }
        }

        [Test]
        public void ShouldCreatePurchaseOrder()
        {
            var purchaseOrderController = new PurchaseOrderController();

            var newPurchaseOrder = purchaseOrderController.NewPurchaseOrder(testCustomer);

            Assert.Greater(newPurchaseOrder.purchaseOrderID, 0);
        }

        [Test]
        public void ShouldAddOrderLines()
        {
            var purchaseOrderController = new PurchaseOrderController();

            var newPurchaseOrder = purchaseOrderController.NewPurchaseOrder(testCustomer);

            foreach (OrderItem o in testOrderItems)
            {
                newPurchaseOrder = purchaseOrderController.addToPurchaseOrder(o, newPurchaseOrder);
            }

            Assert.AreEqual(newPurchaseOrder.purchaseOrderItems.Count, 6);
        }

        [Test]
        public void ShouldCreateShippingSlip()
        {
            var orderItemController = new OrderItemController();
            var purchaseOrderController = new PurchaseOrderController();

            var newPurchaseOrder = purchaseOrderController.NewPurchaseOrder(testCustomer);

            newPurchaseOrder = purchaseOrderController.addToPurchaseOrder(orderItemController.lookupOrderItem("I Rembember it Well"), newPurchaseOrder);

            // TO DO create test to check that shipping slip entry is in DB
            int shippingEntryCustomerID = 0;
            Assert.AreEqual(newPurchaseOrder.customerID, shippingEntryCustomerID);
        }

        [Test]
        public void ShouldImplementMembership()
        {
            var orderItemController = new OrderItemController();
            var purchaseOrderController = new PurchaseOrderController();

            var newPurchaseOrder = purchaseOrderController.NewPurchaseOrder(testCustomer);

            newPurchaseOrder = purchaseOrderController.addToPurchaseOrder(orderItemController.lookupOrderItem("Premium Membership"), newPurchaseOrder);

            // TO DO create test to check that membership has been implemented
            int membershipCustomerID = 0;
            Assert.AreEqual(newPurchaseOrder.customerID, membershipCustomerID);
        }
    }
}
