using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCaseStudy13.Models
{
    public class ViewAccountDetailsVM
    {


        [Required  (ErrorMessage = "Please enter a name")] 
        public string Name { get; set; }

        [Required]
        [Range(100000000, 999999999, ErrorMessage = "Customer SSN must be nine digits")]
        public int SSN { get; set; }


        public int AccountID { get; set; }

    
        [Required]
        [Display(Name = "Customer ID ")]
        [Range(100000000, 999999999, ErrorMessage = "Customer ID must be nine digits")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Please enter an account type")]
        [Display(Name = "Account Type ")]
        public string AccountType { get; set; }

        public string Status { get; set; }

        public DateTime LastUpdated { get; set; }

        //[MaxLength(2, ErrorMessage = "The property {0} can not have more than {1} elements")]
        public int Balance { get; set; }

       // public List<string> Acctype { get; set; }
    }
}
