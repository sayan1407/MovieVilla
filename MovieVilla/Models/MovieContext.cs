using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MovieVilla.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext()
            : base("name=Context")
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
    }
}