using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FinalCaseStudy13.Models
{
    public class CustomerRepo : ICustomerRepo
    {
        context _db;

        public CustomerRepo(context context)
        {
            _db = context;
        }

        //Get all the customers
        public List<Customer> getCustomers()
        {
            return _db.Customer.Where(x => x.Customer_Status != "SOFT DELETE").ToList();
        }



        //get Customer by customer ID
        public List<Customer> getCustomerByID(int id)
        {
            return _db.Customer.Where(x => x.Customer_Status != "SOFT DELETE" && x.ID == id).ToList();
        }

        //get Customer by SSN
        public List<Customer> getCustomerBySSN(int ssn)
        {
            return _db.Customer.Where(x => x.Customer_Status != "SOFT DELETE" && x.SSN == ssn).ToList();
        }

        public int createCustomer(Customer c)
        {
            _db.Add(c);
            _db.SaveChanges();
            return (c.ID);
        }
        
        public void updateCustomer(Customer c)
        {
            _db.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
        }
        public void deleteCustomer(Customer c)
        {

            _db.Customer.Remove(c);
            _db.SaveChanges();
            return;
        }

        //Only use these methods when you need to access the customers which have been soft deleted
        public List<Customer> getSoftDeleteCustomers()
        {
            return _db.Customer.Where(x => x.Customer_Status == "SOFT DELETE").ToList();
        }
    }
}
