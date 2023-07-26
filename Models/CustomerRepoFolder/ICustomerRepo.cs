using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCaseStudy13.Models
{
    public interface ICustomerRepo
    {
        public List<Customer> getCustomers();
        public List<Customer> getCustomerByID(int id);
        public List<Customer> getCustomerBySSN(int ssn);
        public int createCustomer(Customer customer);
        public void updateCustomer(Customer c);
        public void deleteCustomer(Customer c);

        //Only use these methods when you need to access the customers which have been soft deleted
        public List<Customer> getSoftDeleteCustomers();
    }
}
