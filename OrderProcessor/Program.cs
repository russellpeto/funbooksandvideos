using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBV;
using FBV.Objects;

namespace OrderProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new FBVDatabaseContext())
            {
                var customer = new Customer { customerName = "Russell Peto", address = new Address { doorNumber = "5", streetName = "Magri Walk", town = "London", postalCode = "E1 3DU" } };

                db.Customers.Add(customer);
                db.SaveChanges();

                Console.WriteLine("customer peto inserted");

                Console.ReadLine();
            }
        }
    }
}
