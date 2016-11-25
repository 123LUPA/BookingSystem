using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookingSystemFinalProject.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public int Cvr { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }

    public class ResturantContext : DbContext
    {
        public object Restaurant { get; internal set; }
        public DbSet<Restaurant> Restaurants { get; set; }

    }

}