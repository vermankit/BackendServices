using System;
using System.ComponentModel.DataAnnotations;
using BookingService.Enums;

namespace BookingService.Modals
{
    public class Booking
    {
        public Guid Id { get; set; }
<<<<<<< HEAD

        [Required] public Guid PartnerId { get; set; }

        [Required] public string CustomerId { get; set; }

        [Required] public DateTime Slot { get; set; }
=======
        [Required]
        public Guid PartnerId { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [Required]
        public DateTime Slot { get; set; }
>>>>>>> b0c4ad5ecb398d69837623994375c1dd471135b1

        public Status Status { get; set; }
        public long AreaCode { get; set; }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> b0c4ad5ecb398d69837623994375c1dd471135b1
