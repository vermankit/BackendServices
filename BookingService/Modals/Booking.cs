using System;
using System.ComponentModel.DataAnnotations;
using BookingService.Enums;

namespace BookingService.Modals
{
    public class Booking
    {
        [Required] public Guid CustomerId { get; set; }
        [Required] public Guid PartnerId { get; set; }
        public Service RequestedService { get; set; }
        [Required] public DateTime Slot { get; set; }
        public Status Status { get; set; } = Status.Pending;
    }

}

