using BookingSystemFinalProject.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSystemFinalProject.Models.Repositories
{
    public class BookingRepository: IBookingRepository, IDisposable
    {
        BookingContext bookingDb;

       public BookingRepository(BookingContext bookingDb)
        {
            this.bookingDb = bookingDb;
        }

        public void  Delete(int? id)
        {
            Booking booking = bookingDb.Bookings.Find(id);
            bookingDb.Bookings.Remove(booking);
        }

        public Booking findBooking(int? id)
        {
            return bookingDb.Bookings.Find(id);
        }

        public IEnumerable<Booking> getAllBookings()
        {
            return bookingDb.Bookings;

        }

        public void Insert(Booking booking)
        {
          
                bookingDb.Bookings.Add(booking);
            
        }

        public void Update(Booking booking)
        {
           
                bookingDb.Entry(booking).State = System.Data.Entity.EntityState.Modified;
            
        }

        public void Save()
        {
            bookingDb.SaveChanges();
        }

        private bool disposed = false;
  
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    bookingDb.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}