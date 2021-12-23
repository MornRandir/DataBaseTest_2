using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web;

namespace DataBaseTest.Models
{
    class OrderContext : DbContext
    {
        public OrderContext()
            : base("DbConnection")
        { }

        public DbSet<classOrder> Orders { get; set; }
    }
}
