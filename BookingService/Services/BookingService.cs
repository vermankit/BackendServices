using System;
using System.Collections.Generic;
using System.Linq;
using BookingService.Modals;
using BookingService.Services.Interface;

namespace BookingService.Services
{
    public class BookingService : IBookingService
    {
<<<<<<< HEAD
=======
        public static List<Booking> Bookings { get; set; }

>>>>>>> b0c4ad5ecb398d69837623994375c1dd471135b1
        static BookingService()
        {
            Bookings = new List<Booking>();
        }

<<<<<<< HEAD
        public static List<Booking> Bookings { get; set; }

=======
>>>>>>> b0c4ad5ecb398d69837623994375c1dd471135b1
        public Booking Add(Booking booking)
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

        public List<Booking> Get()
        {
            return Bookings;
        }

        public Booking Get(Guid id)
        {
            return Bookings.FirstOrDefault(p => p.Id == id);
        }

<<<<<<< HEAD
=======
        public Booking GetBooking(string email)
        {
            return null;
        }

>>>>>>> b0c4ad5ecb398d69837623994375c1dd471135b1
        public Booking Update(Guid id, Booking booking)
        {
            Bookings.Remove(booking);
            var updatedCustomer = new Booking();
            Bookings.Add(updatedCustomer);
            return updatedCustomer;
        }
<<<<<<< HEAD

        public Booking GetBooking(string email)
        {
            return null;
        }
    }
}
=======
    }
}
>>>>>>> b0c4ad5ecb398d69837623994375c1dd471135b1
