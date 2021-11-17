using BookingService.Enums;
using BookingService.Repositories.Entity;
using BookingService.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingService.Repositories
{
    public class BookingRepository : IBookingRepository
    {

        public static List<BookingEntity> Bookings { get; set; }
        
        static BookingRepository()
        {
            Bookings = new List<BookingEntity>
            {
                new()
                {
                    CustomerEmail = "anu.vig@test.com",
                    Address = "Sample Address",
                    AreaCode = 101,
                    Id = Guid.NewGuid(),
                    Slot = DateTime.Now.AddHours(3),
                    Status = Status.Pending,
                    RequestedService = Service.Cleaner
                }
            };
        }

        public BookingEntity Add(BookingEntity booking)
        {
            var alreadyExist = GetBooking(booking);

            if (alreadyExist != null)
            {
                return alreadyExist;
            }

            booking.Id = booking.Id != default ? booking.Id : Guid.NewGuid();
            booking.Status = Status.Pending;
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
            var existingBooking = Bookings.FirstOrDefault(item => item.Id == id);

            if (existingBooking != null)
            {
                existingBooking.CustomerEmail = booking.CustomerEmail;
                existingBooking.AreaCode = booking.AreaCode;
                existingBooking.ServiceProvideEmail = booking.ServiceProvideEmail;
                existingBooking.Status = booking.Status;
                existingBooking.RequestedService = booking.RequestedService;
                existingBooking.Slot = booking.Slot;
                Bookings.Add(existingBooking);
            }

           
            return existingBooking;
        }


        public BookingEntity GetBooking(BookingEntity bookingEntity)
        {
            return Bookings.FirstOrDefault(b => b.CustomerEmail == bookingEntity.CustomerEmail
            && b.Slot == bookingEntity.Slot);
        }
    }
}

