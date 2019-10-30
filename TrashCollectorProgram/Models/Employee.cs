using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollectorProgram.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public int zipcode { get; set; }
        
        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public void SeePickupsInZipcode(Customer customer)
        {
            
        }
    }
}