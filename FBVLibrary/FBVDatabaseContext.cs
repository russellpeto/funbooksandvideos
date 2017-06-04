using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FBV.objects;

namespace FBV
{
    class FBVDatabaseContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<MediaItem> MediaItems { get; set; }
        public DbSet<Membership> Memberships { get; set; }
    }
}
