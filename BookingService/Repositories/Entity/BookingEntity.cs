using System;
using BookingService.Enums;

namespace BookingService.Repositories.Entity
{
    public class BookingEntity
    {
        public Guid Id { get; set; }
        public string CustomerId { get; set; }
        public Guid ServiceProviderId { get; set; }
        public Service RequestedService { get; set; }
        public DateTime Slot { get; set; }
        public Status Status { get; set; }
        public long AreaCode { get; set; }
    }

}

