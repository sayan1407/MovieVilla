using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieVilla.Models;

namespace MovieVilla.ViewModel
{
    public class CustomerViewModel
    {
        public Customer customer { get; set; }
        public List<MembershipType> membershipTypes { get; set; }
        public string Title { get; set; }
    }
}