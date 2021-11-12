using System;
using System.Collections.Generic;
using BookingService.Modals;

namespace BookingService.Services.Interface
{
    public interface IBookingService
    {
        Booking Add(Booking partner);
        List<Booking> Get();
        Booking Get(Guid id);
        Booking Update(Guid id, Booking partner);
    }
}