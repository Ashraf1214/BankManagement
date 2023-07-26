using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalCaseStudy13.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace FinalCaseStudy13.Controllers
{
    public class CustomerController : Controller
    {
        private static readonly string UniqueSSNStr = @"Violation of UNIQUE KEY constraint";
        private const string EXCEPTION_STR = "An unknown error has occured. Try again later, if problem persists, contact administrator";
        private const int ITEMS_PER_PAGE = 5;
        ICustomerRepo c_repo;
        IAccountRepo a_repo;
        ITransactionRepo t_repo;

        public CustomerController(ICustomerRepo crepo, IAccountRepo arepo, ITransactionRepo trepo)
        {
            c_repo = crepo;
            a_repo = arepo;
            t_repo = trepo;
        }

        public IActionResult ViewCustomers(int page = 1)
        {
            if (TempData["Success"] != null)
                ViewBag.Success = TempData["Success"].ToString();
            if (TempData["Error"] != null)
                ViewBag.Error = TempData["Error"].ToString();

            if (TempData["FilterBy"] != null)
                ViewBag.FilterBy = TempData["FilterBy"].ToString();
            else
                ViewBag.FilterBy = "viewAll";

            ViewCustomersVM vm = new ViewCustomersVM();
            vm.Customers = c_repo.getCustomers();
            vm.CustomersPerPage = ITEMS_PER_PAGE;
            vm.CurrentPage = page;
            return View(vm);
        }

        [HttpPost]
        public IActionResult ViewCustomersByID(int id, int page = 1)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewCustomersVM vm = new ViewCustomersVM();
                    vm.Customers = c_repo.getCustomerByID(id);
                    if (vm.Customers.Count == 0)
                    {
                        TempData["Error"] = $"No Customer found with ID {id}";
                        TempData["FilterBy"] = "viewByID";
                        return RedirectToAction("ViewCustomers");
                    }
                    ViewBag.FilterBy = "viewByID";
                    vm.CustomersPerPage = ITEMS_PER_PAGE;
                    vm.CurrentPage = page;
                    return View("ViewCustomers", vm);
                }
                catch (Exception e)
                {
                    TempData["Error"] = EXCEPTION_STR;
                    TempData["FilterBy"] = "viewByID";
                    return RedirectToAction("ViewCustomers");
                }
            }
            else
            {
                TempData["Error"] = $"No Customer found with ID {id}. Displaying all customers";
                TempData["FilterBy"] = "viewByID";
                return RedirectToAction("ViewCustomers");
            }
        }

        [HttpPost]
        public IActionResult ViewCustomersBySSN(int ssn, int page = 1)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewCustomersVM vm = new ViewCustomersVM();
                    vm.Customers = c_repo.getCustomerBySSN(ssn);
                    if (vm.Customers.Count == 0)
                    {
                        TempData["Error"] = $"No Customer found with SSN: {ssn}. Displaying all customers";
                        TempData["FilterBy"] = "viewBySSN";
                        return RedirectToAction("ViewCustomers");
                    }
                    ViewBag.FilterBy = "viewBySSN";
                    vm.CustomersPerPage = ITEMS_PER_PAGE;
                    vm.CurrentPage = page;
                    return View("ViewCustomers", vm);
                }
                catch (Exception e)
                {
                    TempData["Error"] = EXCEPTION_STR;
                    TempData["FilterBy"] = "viewBySSN";
                    return RedirectToAction("ViewCustomers");
                }
            }
            else
            {
                TempData["Error"] = $"No Customer found with SSN {ssn}";
                TempData["FilterBy"] = "viewBySSN";
                return RedirectToAction("ViewCustomers");
            }
        }
        public IActionResult AddCustomer()
        {
            Customer c = new Customer();
            c.Customer_Status = "Uncreated";
            c.Status_Last_Updated = new DateTime(1996, 11, 07);
            return View(c);
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            customer.Customer_Status = "Customer added";
            customer.Status_Last_Updated = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    c_repo.createCustomer(customer);
                    ViewBag.Success = "Customer added successully";
                    return View();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                {
                    Regex UniqueSSNRegex = new Regex(UniqueSSNStr);
                    Match uniqueMatch = UniqueSSNRegex.Match(ex.InnerException.Message);
                    if (uniqueMatch.Success)
                    {
                        ViewBag.Error = $"The SSN {customer.SSN} already belongs to a registered customer";
                    }
                    else
                        ViewBag.Error = $"Customer could not be created, ensure all fields are correct. If problem persists, contact administrator";
                    return View(customer);
                }
                catch (Exception e)
                {
                    ViewBag.Error = EXCEPTION_STR;
                    return View(customer);
                }
            }
            else
                ViewBag.Error = $"Fix errors in the fields below. If no errors appear, contact administrator";
            return View(customer);
        }

        public IActionResult UpdateCustomer(int ID)
        {
            return View(c_repo.getCustomerByID(ID)[0]);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    customer.Customer_Status = "Customer details updated";
                    customer.Status_Last_Updated = DateTime.Now;
                    c_repo.updateCustomer(customer);
                    TempData["Success"] = "Customer updated successfully";
                    return RedirectToAction("ViewCustomers");
                }
                catch (Exception e)
                {
                    ViewBag.Error = EXCEPTION_STR;
                    return View(customer);
                }
            }
            else
            {
                ViewBag.Error = $"Changes made are invalid, ensure all fields are valid.";
                return View(customer);
            }
        }

        public IActionResult DeleteCustomer(int ID)
        {
            return View(c_repo.getCustomerByID(ID)[0]);
        }

        [HttpPost]
        public IActionResult DeleteCustomer(Customer customer)
        {
            try
            {
                List<Account> custAccounts = a_repo.GetAccountsByCID(customer.ID);
                if (custAccounts.Count > 0)
                {
                    TempData["Error"] = "Customer still has open account(s), cannot remove customer at this time.";
                    return RedirectToAction("ViewCustomers");
                }
                else
                {

                    if (a_repo.getSoftDeleteAccountsByCID(customer.ID).Count > 0)
                    {
                        customer.Customer_Status = "SOFT DELETE";
                        customer.Status_Last_Updated = DateTime.Now;
                    }
                    else
                    {
                        c_repo.deleteCustomer(customer);
                    }
                    TempData["Success"] = "Customer deleted successfully";
                    return RedirectToAction("ViewCustomers");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ViewBag.Error = EXCEPTION_STR;
                return View(customer);
            }
        }


        //    [Authorize(Roles = "Account-Executive, Customer-Executive")]
        //    // SEARCHING BY CONDITIONS
        //    [HttpGet]
        //    public IActionResult Search()
        //    {
        //        return View();
        //    }

        //    [HttpPost]
        //    //public IActionResult Search(Customer c)
        //    //{

        //    //    Customer customer = c_repo.getCustomerByID(c.ID);
        //    //    Customer customer1 = c_repo.getCustomerBySSN(c.SSN);

        //    //    if (customer == null && c.ID != 0)
        //    //    {
        //    //        ViewBag.Error = $"No Customer found with Customer ID: {c.ID}";
        //    //        return View("Search");
        //    //    }

        //    //    else if (c.ID != 0)
        //    //    {
        //    //        return View(c_repo.getCustomerByID(c.ID));
        //    //    }

        //    //    else if (customer1 == null && c.SSN != 0)
        //    //    {
        //    //        ViewBag.Error = $"No Customer found with SSN: {c.SSN}";
        //    //        return View("Search");
        //    //    }

        //    //    else if (c.SSN != 0)
        //    //    {
        //    //        return View(c_repo.getCustomerBySSN(c.SSN));
        //    //    }

        //    //    else
        //    //        return View("Search");

        //    //}
        //}
    }
}
