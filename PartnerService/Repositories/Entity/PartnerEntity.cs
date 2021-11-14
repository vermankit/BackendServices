using PartnerService.Enum;
using System;

namespace PartnerService.Repositories.Entity
{
    public class PartnerEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public long AreaCode { get; set; }
        public Service Profession { get; set; }
    }
}
