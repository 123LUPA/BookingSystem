using BookingSystemFinalProject.Models;
using BookingSystemFinalProject.Models.Abstract;
using BookingSystemFinalProject.Models.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace BookingSystemFinalProject.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private ResturantContext restaurantContext = new ResturantContext();


        private IBookingRepository bookingRepository;

        public BookingsController()
        {
            this.bookingRepository = new BookingRepository(new BookingContext());
        }

        public BookingsController(IBookingRepository bookingRepo)
        {
            this.bookingRepository = bookingRepo;

        }

        // GET: Bookings
        public ActionResult Index()
        {


            var id = User.Identity.GetUserId();

            var bookings = from a in bookingRepository.getAllBookings()
                           where a.UserId.Contains(id)
                           select a;

            return View(bookings);
        }

        // GET: Bookings/Details/5
        public ViewResult Details(int? id)
        {
            
            Booking booking = bookingRepository.findBooking(id);
            return View(booking);
        }

        // GET: Bookings/Create
        [AllowAnonymous]
        public ActionResult Create()
        {


            var restaurantsId = from a in restaurantContext.Restaurants
                           select a.Id;



            
            ViewBag.DropDownValues1 = new SelectList(restaurantsId);

         



            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RestaurantId,BookingDate,MyProperty,NumberOfPeople")] Booking booking)
        {
            

            var id = User.Identity.GetUserId();
            booking.UserId = id;

            if (ModelState.IsValid)
            {
                bookingRepository.Insert(booking);
                bookingRepository.Save();

                    return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = bookingRepository.findBooking(id);

            if (booking == null)
            {
                return HttpNotFound();
            }

            bookingRepository.Update(booking);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,RestaurantId,BookingDate,MyProperty,NumberOfPeople")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                bookingRepository.Update(booking);
                bookingRepository.Save();

                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = bookingRepository.findBooking(id);
           
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {

           Booking booking = bookingRepository.findBooking(id);

           bookingRepository.Delete(id);
            bookingRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            bookingRepository.Dispose();
            base.Dispose(disposing);
        }


    }
}
