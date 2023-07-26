using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FinalCaseStudy13.Models;

namespace FinalCaseStudy13.Models
{
    public class AccountTransaction
    {



        public Account AccountObject { get; set; }
        public Transaction TransactionObject { get; set; }
    }
}
