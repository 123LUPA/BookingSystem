using BookingSystemFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookingSystemFinalProject.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfPeople { get; set; }
        public int Seat { get; set; }
    }
}
public class BookingContext : DbContext
{
    public DbSet<Booking> Bookings { get; set; }

}
