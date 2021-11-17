using System;
using System.Collections.Generic;
using BookingService.Repositories.Entity;

namespace BookingService.Repositories.Interface
{
    public interface IBookingRepository
    {
        BookingEntity Add(BookingEntity partner);
        List<BookingEntity> Get();
        BookingEntity Get(Guid id);
        BookingEntity Get(string id);
        BookingEntity Update(Guid id, BookingEntity partner);
    }
}
