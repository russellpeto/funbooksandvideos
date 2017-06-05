using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FBVLibrary;
using FBV.Objects;
using FBV.Controllers;

namespace Tests.Objects
{
    [TestFixture]
    class CustomerTests
    {
        [Test]
        public void ShouldCreateCustomer()
        {
            var customerController = new CustomerController();

            var customer = customerController.NewCustomer();

            Assert.IsNotNull(customer);
        }

        [Test]
        public void ShouldSaveCustomerToDatabase()
        {
            var customerController = new CustomerController();

            var customerToCreate = new Customer { customerName = "Russell Peto", address = new Address { doorNumber = "5", streetName = "Magri Walk", postalCode = "E1 3DU", town = "London", country = "UK" } };

            Customer createdCustomer = customerController.NewCustomer(customerToCreate);

            Assert.Greater(createdCustomer.customerID, 0);
        }

        [Test]
        public void ShouldUpdateCustomer()
        {
            var customerController = new CustomerController();

            var customerToCreate = new Customer { customerName = "Russell Peto", address = new Address { doorNumber = "5", streetName = "Magri Walk", postalCode = "E1 3DU", town = "London", country = "UK" } };

            Customer createdCustomer = customerController.NewCustomer(customerToCreate);

            createdCustomer.address.addressLine2 = "Whitechapel";

            Customer updatedCustomer = customerController.UpdateCustomer(createdCustomer);

            Assert.AreEqual(updatedCustomer.address.addressLine2, "Whitechapel");
        }
    }
}
