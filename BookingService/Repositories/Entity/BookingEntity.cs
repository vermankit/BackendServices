using BookingService.Enums;
using System;

namespace BookingService.Repositories.Entity
{
    public class BookingEntity
    {
        public Guid Id { get; set; }
        public string CustomerEmail { get; set; }
        public string ServiceProvideEmail { get; set; }
        public Service RequestedService { get; set; }
        public DateTime Slot { get; set; }
        public Status Status { get; set; }
        public long AreaCode { get; set; }
        public string Address { get; set; }
        public string BookingNumber { get; set; }
    }

}

