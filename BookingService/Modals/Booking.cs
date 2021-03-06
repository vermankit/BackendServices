using BookingService.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookingService.Modals
{
    public class Booking
    {

        [Required] public string CustomerEmail { get; set; }
        [Required]
        public Service RequestedService { get; set; }
        public string ServiceProvideEmail { get; set; }
        [Required] public DateTime Slot { get; set; }
        [Required] public string AreaCode { get; set; }
        public Status Status { get; set; }
        public string BookingNumber { get; set; }
    }

}

