using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCaseStudy13.Models
{ 
    public class ViewCustomersVM
    {
        public int? ID { get; set; }
        public int? SSN { get; set; }
        public List<Customer> Customers { get; set; }
        public int CustomersPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Customers.Count() / (double)CustomersPerPage));
        }

        public List<Customer> PaginatedCustomers()
        {
            int start = (CurrentPage - 1) * CustomersPerPage;
            return Customers.Skip(start).Take(CustomersPerPage).ToList();
        }
    }
}
