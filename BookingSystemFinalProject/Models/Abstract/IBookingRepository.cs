using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemFinalProject.Models.Abstract
{
    public interface IBookingRepository: IDisposable
    {
        IEnumerable<Booking> getAllBookings();
        Booking findBooking(int? id);
        void Insert(Booking booking);
        void Update(Booking booking);
        void Delete(int? id);
        void Save();


        
    }
}
