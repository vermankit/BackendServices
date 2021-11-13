using System;
using System.Collections.Generic;
using BookingService.Modals;
using BookingService.Services.Entity;

namespace BookingService.Services.Interface
{
    public interface IBookingService
    {
        BookingEntity Add(BookingEntity partner);
        List<BookingEntity> Get();
        BookingEntity Get(Guid id);
        BookingEntity Update(Guid id, BookingEntity partner);
    }
}
