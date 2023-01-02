using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieVilla.Models
{
    public class Customer
    {
        
        public long Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        [Required]
        [Display(Name ="Membersip Type")]
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}