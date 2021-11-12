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
<<<<<<< HEAD
}
=======
}
>>>>>>> b0c4ad5ecb398d69837623994375c1dd471135b1
