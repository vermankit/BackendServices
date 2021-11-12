using System;
using System.ComponentModel.DataAnnotations;
using BookingService.Enums;

namespace BookingService.Modals
{
    public class Booking
    {
        public Guid Id { get; set; }


        [Required] public Guid PartnerId { get; set; }

        [Required] public string CustomerId { get; set; }

        [Required] public DateTime Slot { get; set; }


        public Status Status { get; set; }
        public long AreaCode { get; set; }
    }

}

