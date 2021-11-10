using System;

namespace PartnerService.Modals
{
    public class Partner
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Profession { get; set; }
    }
}
