using Netbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netbox.ViewModels
{
    public class NewCustomerViewModel
    {
        //public List<MembershipType> MembershipTypes { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}