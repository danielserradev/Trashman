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
        public Guid Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string stateCode { get; set; }
        public int zipcode { get; set; }
        public double balance { get; set; }
        public bool pickupConfirmed { get; set; }
        public DateTime pickUpDate { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}