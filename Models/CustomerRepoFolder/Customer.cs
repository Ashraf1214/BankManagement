using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCaseStudy13.Models 
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Range(100000000, 999999999, ErrorMessage = "Customer {0} must be nine digits")]
        public int? SSN { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(16, 100, ErrorMessage = "Customer {0} must be between {1} and {2}")]
        public int? Age { get; set; }

        [Required (ErrorMessage = "The Address field is required")]
        [Display(Name = "Address Line 1 ")]
        public string Address_1 { get; set; }

        [Display(Name = "Address Line 2 ")]
        public string Address_2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        
        [Display(Name = "Customer Status ")]
        public string Customer_Status { get; set; }

        [Display(Name = "Last Updated ")]
        public DateTime Status_Last_Updated { get; set; }
    }

}
