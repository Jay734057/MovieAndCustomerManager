

using System.ComponentModel.DataAnnotations;

namespace MovieAndCustomerManager.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool isSubcribedToNewsletter { get; set; }
        public MembershipType MenbershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}