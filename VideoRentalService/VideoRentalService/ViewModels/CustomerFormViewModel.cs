using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalService.Models;

namespace VideoRentalService.ViewModels
{
    public class CustomerFormViewModel
    {
        // IEnumberable chosen over List as we only need "view only" permissions rather than manipulating a list.
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}