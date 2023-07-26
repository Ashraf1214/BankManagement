using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCaseStudy13.Models
{
    public class ViewAccountDetails2VM
    {
        public int? ID { get; set; }
        public int? SSN { get; set; }
        public List<ViewAccountDetailsVM> Accounts { get; set; }
        public int AccountsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Accounts.Count() / (double)AccountsPerPage));
        }

        public List<ViewAccountDetailsVM> PaginatedAccounts()
        {
            int start = (CurrentPage - 1) * AccountsPerPage;
            return Accounts.Skip(start).Take(AccountsPerPage).ToList();
        }
    }
}
