using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalCaseStudy13.Models
{
    public class viewmodelDate
    {
        public viewmodel3 v { get; set; }
        [Required]
        [Display(Name="End date")]
        public DateTime d { get; set; }
        [Required]
        [Display(Name ="Start date")]
        public DateTime e { get; set; }
        [Required]
        [Display(Name ="Account ID")]
        public int ID { get; set; }
        [Required]
        [Display(Name ="# Of Transaction")]
        public int count { get; set; }
    }
}
