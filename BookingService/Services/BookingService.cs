using System;
using System.Collections.Generic;
using System.Linq;
using BookingService.Modals;
using BookingService.Services.Entity;
using BookingService.Services.Interface;

namespace BookingService.Services
{
    public class BookingService : IBookingService
    {

        public static List<BookingEntity> Bookings { get; set; }
        
        static BookingService()
        {
            Bookings = new List<BookingEntity>();
        }

        public BookingEntity Add(BookingEntity booking)
        {
            //var alreadyExist = GetBooking(booking.CustomerId,booking.PartnerId);

            //if (alreadyExist != null)
            //{
            //    return alreadyExist;
            //}

            booking.Id = booking.Id != default ? booking.Id : Guid.NewGuid();
            Bookings.Add(booking);

            return booking;
        }

        public List<BookingEntity> Get()
        {
            return Bookings;
        }

        public BookingEntity Get(Guid id)
        {
            return Bookings.FirstOrDefault(p => p.Id == id);
        }




        public BookingEntity Update(Guid id, BookingEntity booking)
        {
            Bookings.Remove(booking);
            var updatedCustomer = new BookingEntity();
            Bookings.Add(updatedCustomer);
            return updatedCustomer;
        }


        public Booking GetBooking(string email)
        {
            return null;
        }
    }
}

