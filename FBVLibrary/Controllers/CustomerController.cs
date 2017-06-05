using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBV.Objects;

namespace FBV.Controllers
{
    public class CustomerController
    {
        public Customer NewCustomer()
        {
            using(var db = new FBVDatabaseContext())
            {
                Customer newCustomer = db.Customers.Create();
                db.Customers.Add(newCustomer);
                db.SaveChanges();

                return newCustomer;
            }
        }
        public Customer NewCustomer(Customer newCustomer)
        {
            using (var db = new FBVDatabaseContext())
            {
                db.Customers.Add(newCustomer);
                db.SaveChanges();
                return newCustomer;
            }
        }
        public Customer UpdateCustomer(Customer customerToUpdate)
        {
            using(var db = new FBVDatabaseContext())
            {
                var c = GetCustomerFromID(customerToUpdate.customerID);
                db.Entry(c).CurrentValues.SetValues(customerToUpdate);
                db.SaveChanges();

                return c;
            }
        }
        public void DeleteCustomer(Customer customerToDelete)
        {
            using (var db = new FBVDatabaseContext())
            {
                db.Customers.Remove(customerToDelete);
            }
        }

        public Customer GetCustomerFromID(int requiredCustomerID)
        {
            using(var db = new FBVDatabaseContext())
            {
                try
                {
                    Customer desiredCustomer = db.Customers.Single(n => n.customerID == requiredCustomerID);

                    return desiredCustomer;
                }
                catch
                {
                    throw new Exception("Customer not found with specified ID");
                }
            }
        }
        public List<Customer> GetCustomersFromName(string requiredCustomerName)
        {
            using (var db = new FBVDatabaseContext())
            {
                try
                {
                    List<Customer> desiredCustomers = (from c in db.Customers
                                                       where c.customerName == requiredCustomerName
                                                       orderby c.customerName
                                                       select c).ToList();

                    return desiredCustomers;
                }
                catch
                {
                    throw new Exception("No customers found with specified name");
                }
            }
        }
    }
}
