using System;
using System.ComponentModel.DataAnnotations;
using BookingService.Enums;

namespace BookingService.Modals
{
    public class Booking
    {
        [Required] public string CustomerEmail { get; set; }
        [Required]
        public Service RequestedService { get; set; }
        [Required] public DateTime Slot { get; set; }
        [Required] public string AreaCode { get; set; }
    }

}

