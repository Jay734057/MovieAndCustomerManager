using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MovieAndCustomerManager.Models;


namespace MovieAndCustomerManager.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }


        //[Required(ErrorMessage = "Please enter customer's name.")]
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //[AgeLimitForMembership]
        public DateTime? Birthdate { get; set; }

        public bool isSubcribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}