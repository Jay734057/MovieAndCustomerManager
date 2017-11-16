using System.Collections.Generic;
using MovieAndCustomerManager.Models;

namespace MovieAndCustomerManager.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}