using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalCaseStudy13.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }

        [Required (ErrorMessage = "Balance Required")]
        [Range(100000000, 999999999, ErrorMessage = "{0} must be between {1} and {2}")]
        [Display(Name = "Customer ID")]
        public int Customer_ID { get; set; }

        [Required]
        [Display(Name = "Account Type")]
        public string Account_Type { get; set; }
       
     
        [Display(Name = "Account Status")]
        public string Account_Status { get; set; }
       
       
        [Display(Name = "Last Updated")]
        public DateTime Status_Last_Updated { get; set; }


        //[Range(100, int.MaxValue, ErrorMessage = "The inital deposit must be $100 or more")]
        public int Balance { get; set; }
    }
}
