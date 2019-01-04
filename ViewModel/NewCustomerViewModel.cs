using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
namespace Vidly.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipTypes> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}