using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCaseStudy13.Models
{
    public class ViewCustomerAccountsVM
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public List<ViewAccountDetailsVM> CustomerAccounts { get; set; }
    }
}
