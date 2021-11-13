using System;
using System.Collections.Generic;
using BookingService.Services.Entity;

namespace BookingService.Repositories.Interface
{
    public interface IBookingRepository
    {
        BookingEntity Add(BookingEntity partner);
        List<BookingEntity> Get();
        BookingEntity Get(Guid id);
        BookingEntity Update(Guid id, BookingEntity partner);
    }
}
