using PartnerService.Enum;

namespace PartnerService.Modals
{
    public class Partner
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public long AreaCode { get; set; }
        public Service Profession { get; set; }

    }
}