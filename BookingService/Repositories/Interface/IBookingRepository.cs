using BookingService.Repositories.Entity;
using System;
using System.Collections.Generic;

namespace BookingService.Repositories.Interface
{
    public interface IBookingRepository
    {
        BookingEntity Add(BookingEntity partner);
        List<BookingEntity> Get();
        BookingEntity Get(string bookingNumber);
        BookingEntity Get(Guid id);
        BookingEntity Update(string id, BookingEntity partner);
    }
}
