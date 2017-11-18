

using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAndCustomerManager.Models
{
    public class Customer
    {
        public int Id { get; set; }


        //[Required(ErrorMessage = "Please enter customer's name.")]
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [AgeLimitForMembership]
        public DateTime? Birthdate { get; set; }

        public bool isSubcribedToNewsletter { get; set; }

        
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}