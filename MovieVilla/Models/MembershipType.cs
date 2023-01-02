using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieVilla.Models
{
    public class MembershipType
    {
        [Required]
        public byte MembershipTypeId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public byte duration { get; set; }
        [Required]
        public int discount { get; set; }

    }
}