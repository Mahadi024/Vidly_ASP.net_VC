using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18IfAMember]
        public DateTime? BirthDate { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipTypes MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MemberShipTypeId { get; set; }

    }
}