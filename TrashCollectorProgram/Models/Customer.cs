using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollectorProgram.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required]
        [Display(Name = "Street Address")]
        public string streetAddress { get; set; }
        [Required]
        [Display(Name = "City")]
        public string city { get; set; }
        [Required]
        [Display(Name = "State Code")]
        public string stateCode { get; set; }
        [Required]
        [Display(Name = "ZIP Code")]
        public int zipcode { get; set; }
        
        [Display(Name = "Balance")]
        public double balance { get; set; }
        
        public bool pickupConfirmed { get; set; }
        [Required]
        [Display(Name = "Pickup Day")]
        public DayOfWeek pickUpDay { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Extra Pickup Date")]
        public DateTime? pickUpDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Suspension Start Date")]
        public DateTime? startDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Suspension End Date")]
        public DateTime? endDate { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
    }
}