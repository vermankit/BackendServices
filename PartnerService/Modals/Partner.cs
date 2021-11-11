using System;
using System.ComponentModel.DataAnnotations;

namespace PartnerService.Modals
{
    public class Partner
    {
        public Partner()
        {

        }
        public Partner(Guid id, Partner partner)
        {
            Id = id;
            FirstName = partner.FirstName;
            LastName = partner.LastName;
            Gender = partner.Gender;
            Profession = partner.Profession;
            Email = partner.Email;
        }

        public Guid Id { get; set; }

        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Profession { get; set; }
    }
}
