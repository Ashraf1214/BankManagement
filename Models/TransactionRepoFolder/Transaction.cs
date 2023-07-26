using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCaseStudy13.Models
{
    public class Transaction
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Account ID")]
        public int Account_ID { get; set; }

        
        [Display(Name = "Account ID 2")]
        public int? Account_ID_2 { get; set; }

        //[Required]
        public string Transaction_Type { get; set; }

        [Required]
        public int Amount { get; set; }

        public DateTime TranDate { get; set; }
        public int Balance { get; set; }
    }
}
