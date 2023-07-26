using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalCaseStudy13.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using X.PagedList;


namespace FinalCaseStudy13.Controllers
{

    public class AccountController : Controller
    {
        private const string EXCEPTION_STR = "An unknown error has occured. Try again later, if problem persists, contact administrator";
        private const int ITEMS_PER_PAGE = 5;
        ICustomerRepo cRepo;
        ITransactionRepo tRepo;
        IAccountRepo aRepo;
        public AccountController(IAccountRepo AcRepo, ITransactionRepo TrRepo, ICustomerRepo CuRepo)
        {
            cRepo = CuRepo;
            tRepo = TrRepo;
            aRepo = AcRepo;
        }

        public IActionResult ViewAccountDetails(int page = 1)
        {
            if (TempData["Success"] != null)
                ViewBag.Success = TempData["Success"].ToString();
            if (TempData["Error"] != null)
                ViewBag.Error = TempData["Error"].ToString();

            if (TempData["FilterBy"] != null)
                ViewBag.FilterBy = TempData["FilterBy"].ToString();
            else
                ViewBag.FilterBy = "viewAll";

            ViewAccountDetails2VM vm = new ViewAccountDetails2VM();
            vm.Accounts = aRepo.getAccountDetails();
            vm.AccountsPerPage = ITEMS_PER_PAGE;
            vm.CurrentPage = page;
            return View(vm);
        }
        //Page to view an account by ID

        [HttpPost]
        public IActionResult ViewAccountById(int id, int page = 1)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewAccountDetails2VM vm = new ViewAccountDetails2VM();
                    vm.Accounts = aRepo.GetByAID(id);
                    if (vm.Accounts == null)
                    {
                        TempData["Error"] = $"No account found with ID: {id}. Displaying all accounts";
                        TempData["FilterBy"] = "viewByID";
                        return RedirectToAction("ViewAccountDetails");
                    }
                    ViewBag.FilterBy = "viewByID";
                    vm.AccountsPerPage = ITEMS_PER_PAGE;
                    vm.CurrentPage = page;
                    return View("ViewAccountDetails", vm);
                }
                catch (Exception e)
                {
                    TempData["Error"] = EXCEPTION_STR;
                    TempData["FilterBy"] = "viewByID";
                    return RedirectToAction("ViewAccountDetails");
                }
            }
            else
            {
                TempData["Error"] = $"No account found with ID {id}";
                TempData["FilterBy"] = "viewByID";
                return RedirectToAction("ViewAccountDetails");
            }
        }

        [HttpGet]
        public IActionResult ViewCustomerAccounts(int id, string name)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewCustomerAccountsVM vm = new ViewCustomerAccountsVM();
                    vm.CustomerID = id;
                    vm.CustomerName = name;
                    vm.CustomerAccounts = aRepo.GetByCID2(id);
                    if (vm.CustomerAccounts == null)
                    {
                        ViewBag.Error = "Customer does not have an account";
                    }
                    return View(vm);
                }
                else
                {
                    ViewCustomerAccountsVM vm = new ViewCustomerAccountsVM();
                    vm.CustomerID = id;
                    vm.CustomerName = name;
                    ViewBag.Error = "The database could not be accessed because the model state was invalid. Contact Administrator if problem persists.";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = EXCEPTION_STR;
                return View();
            }
        }
        //Action Method for depositing amount
        [Authorize(Roles = "Cashier, Teller")]
        [HttpGet]
        public IActionResult Deposit(int id)
        {
            Account obj = aRepo.GetbyID(id); //created an object of Account and stored GetbyID method of type "Account" in obj
            viewmodel3 v = new viewmodel3();
            v.a = obj;
            //v.t = new Transactions();
            return View(v);
        }
        [HttpPost]
        public IActionResult Deposit(viewmodel3 v)
        {
            v.t.Account_ID = v.a.ID;
            v.t.Transaction_Type = "Deposit";
            v.t.Account_ID_2 = null;
            v.a.Status_Last_Updated = DateTime.Today;
            v.t.TranDate = DateTime.Today;
            v.t.Balance = v.t.Amount + v.a.Balance;

            if (ModelState.IsValid)
            {
                v.a.Balance = v.a.Balance + v.t.Amount;
                tRepo.add(v.t);
                aRepo.update(v.a);
                ViewBag.Success = "Deposit Successful";
                return View(v);
            }
            else
                return View(v);
        }

        [HttpPost]
        public IActionResult ViewAccountBySSN(int ssn, int page = 1)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewAccountDetails2VM vm = new ViewAccountDetails2VM();
                    vm.Accounts = aRepo.GetBySSN(ssn);
                    if (vm.Accounts == null)
                    {
                        TempData["Error"] = $"No account found with SSN: {ssn}. Displaying all accounts";
                        TempData["FilterBy"] = "viewBySSN";
                        return RedirectToAction("ViewAccountDetails");
                    }
                    ViewBag.FilterBy = "viewBySSN";
                    vm.AccountsPerPage = ITEMS_PER_PAGE;
                    vm.CurrentPage = page;
                    return View("ViewAccountDetails", vm);
                }
                catch (Exception e)
                {
                    TempData["Error"] = EXCEPTION_STR;
                    TempData["FilterBy"] = "viewBySSN";
                    return RedirectToAction("ViewAccountDetails");
                }
            }
            else
            {
                TempData["Error"] = $"No account found with SSN {ssn}";
                TempData["FilterBy"] = "viewBySSN";
                return RedirectToAction("ViewAccountDetails");
            }
        }

        [Authorize(Roles = "Cashier, Teller")]
        [HttpGet]
        public IActionResult Withdraw(int id)
        {
            Account obj = aRepo.GetbyID(id); //created an object of Account and stored GetbyID method of type "Account" in obj
            viewmodel3 v = new viewmodel3();
            v.a = obj;
            //v.t = new Transactions();
            return View(v);
        }
        [HttpPost]
        public IActionResult Withdraw(viewmodel3 v)
        {
            v.t.Account_ID = v.a.ID;
            v.t.Transaction_Type = "Withdrawl";
            v.t.Account_ID_2 = null;
            v.a.Status_Last_Updated = DateTime.Today;
            v.t.TranDate = DateTime.Today;
            v.t.Balance = v.a.Balance - v.t.Amount;

            if (ModelState.IsValid)
            {
                if (v.a.Balance >= v.t.Amount)
                {
                    v.a.Balance = v.a.Balance - v.t.Amount;
                    tRepo.add(v.t);
                    aRepo.update(v.a);
                    ViewBag.Success = "Withdrawal Successful";
                    return View(v);
                }
                else
                {
                    ViewBag.ErrorMessage = "Withdraw amount is more than available balance";
                    return View("Withdraw");
                }
            }
            else
                return View(v);
        }


        [Authorize(Roles = "Cashier, Teller")]
        //Action Method for Transferring Amount
        [HttpGet]
        public IActionResult Transfer(int id)
        {
            Account obj = aRepo.GetbyID(id);
            viewmodel3 v = new viewmodel3();
            v.a = obj;
            return View(v);
        }
        [HttpPost]
        public IActionResult Transfer(viewmodel3 v)
        {

            v.t.Account_ID = v.a.ID;
            v.t.Transaction_Type = "Transfer";
            v.a.Status_Last_Updated = DateTime.Today;
            v.t.TranDate = DateTime.Today;
            v.t.Balance = v.a.Balance - v.t.Amount;
            Account obj = aRepo.GetbyID((int)v.t.Account_ID_2);
            viewmodel3 s = new viewmodel3();
            s.a = obj;
            try
            {
                if (s.a == null)
                {
                    throw new Exception();
                }
                if (ModelState.IsValid)
                {
                    if (v.a.Balance >= v.t.Amount)
                    {
                        v.a.Balance = v.a.Balance - v.t.Amount;
                        s.a.Balance = s.a.Balance + v.t.Amount;
                        tRepo.add(v.t);
                        aRepo.update(v.a);
                        ViewBag.Success = "Transfer Successful";
                        Transaction t = new Transaction();
                        t.Account_ID = s.a.ID;
                        t.Account_ID_2 = v.a.ID;
                        t.Amount = v.t.Amount;
                        t.Balance = s.a.Balance;
                        t.Transaction_Type = "Transfer";
                        tRepo.add(t);
                        return View("Transfer");
                    }
                    else
                    {
                        ViewBag.ErrorMessage1 = "Not enough balance to transfer";
                        return View("Transfer");
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage2 = $"Invalid Account ID, Account {v.t.Account_ID_2} doesn't exist";
                return View("Transfer");

            }

            return View();

        }
        [Authorize(Roles = "Cashier, Teller")]
        //Actionmethod for viewing statement
        [HttpGet]
        public IActionResult SearchSbyID()
        {
            viewmodelDate d = new viewmodelDate();
            return View(d);
        }
        [HttpPost]
        public IActionResult ViewStatementbyAccID(viewmodelDate obj, int? page)
        {
            List<viewmodel3> List = aRepo.Dates(obj);

            try
            {
                if (List.Count == 0)
                {
                    throw new Exception();
                }
                {
                    if (ModelState.IsValid)
                    {
                        //int pageSize = 5;
                        //int pageNumber = (page ?? 1);
                        //return View(List.ToPagedList(pageNumber, pageSize));
                        return View(List);
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Invalid input(s)";
                return View();
            }
            return View();
        }
        // action method to call, in cshtml via javascript for pdf printing
        public IActionResult generatePDF(string html)
        {
            html = html.Replace("StrTag", "<").Replace("EndTag", ">");
            HtmlToPdf oHtmlToPdf = new HtmlToPdf();
            PdfDocument oPdfDocument = oHtmlToPdf.ConvertHtmlString(html);
            byte[] pdf = oPdfDocument.Save();
            oPdfDocument.Close();

            return File(
                pdf,
                "application/pdf",
                "BankStatement.pdf");
        }


        [Authorize(Roles = "Cashier, Teller")]
        //view by account ID/ssn/customer ID
        [HttpGet]
        public IActionResult viewAsCashier()
        {
            ViewAccountDetailsVM v = new ViewAccountDetailsVM();
            return View(v);
        }

        [HttpPost]
        public IActionResult result(ViewAccountDetailsVM model)
        {
            List<ViewAccountDetailsVM> v = new List<ViewAccountDetailsVM>();
            if (model.CustomerID != 0)
            {
                v = aRepo.GetByCID2(model.CustomerID);
                if (v == null)
                    ViewBag.Error1 = $"Customer with ID {model.CustomerID} doesn't exist";
                else
                    return View(v);
            }
            else if (model.SSN != 0)
            {
                v = aRepo.GetBySSN(model.SSN);
                if (v == null)
                    ViewBag.Error2 = $"Customer with SSN {model.SSN} doesn't exist";
                else
                    return View(v);
            }
            else
            {
                v = aRepo.GetByaccID(model.AccountID);
                if (v.Count == 0)
                    ViewBag.Error3 = $"Account ID {model.AccountID} doesn't exist";
                else
                    return View(v);
            }
            return View();

        }

        // VIEW ALL ACCOUNTS
        public IActionResult ViewAll()
        {
            return View(aRepo.viewAccounts());
        }











        [Authorize(Roles = "Account-Executive, Customer-Executive")]
        // ADDING A NEW ACCOUNT 
        public IActionResult AddAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAccount(Account a)
        {
            a.Status_Last_Updated = DateTime.Now;
            a.Account_Status = "ACCOUNT CREATED";

            if (ModelState.IsValid)
            {
                int res = aRepo.AddAccount(a);
                if (res == 1 || res == 2)
                {
                    ViewBag.M1 = "This account already exists.";
                    return View();
                }

                else
                {
                    ViewBag.M3 = "Account was added successfully.";
                    return View();
                }

                // return RedirectToAction("ViewAll");
            }
            else
                return View();
        }


        [Authorize(Roles = "Account-Executive, Customer-Executive")]
        // DELETING AN ACCOUNT

        [HttpGet]
        public IActionResult DeleteAccount(int ID)
        {
            return View(aRepo.GetbyID(ID));
        }
        [HttpPost]
        public IActionResult DeleteAccount(Account a)
        {
            Transaction tran = aRepo.getTransferByaccountID(a);


            if (ModelState.IsValid && a.Balance == 0)
            {
                if (tran == null)
                {
                    aRepo.DelAccount(a);
                    TempData["Success"] = "Customer deleted successfully";
                    return RedirectToAction("viewAccountDetails");
                }

                else
                {
                    a.Account_Status = "Soft Delete";
                    a.Status_Last_Updated = DateTime.Now;
                    aRepo.update(a);
                    TempData["Success"] = "Customer deleted successfully";
                    ViewBag.M3 = "Account successfully deleted";
                    return RedirectToAction("viewAccountDetails");
                }
            }


            else
            {
                ViewBag.M2 = "Error: Balance must be taken out before deleting";
                ModelState.Clear();
                return View(aRepo.GetbyID(a.ID));
            }
            //List<Transaction> nullTransfers = tRepo.getNullTransfers();
            //foreach (Transaction t in nullTransfers)
            //{
            //    if (ModelState.IsValid)
            //        tRepo.deleteTransactions(t);
            //}
            //List<Account> softDeleteAccounts = aRepo.getSoftDeleteAccounts();
            //foreach (Account acc in softDeleteAccounts)
            //{
            //    List<Transaction> custTransfers = tRepo.getTransferByAccountID(acc.ID);
            //    if (custTransfers.Count > 0)
            //    {
            //        List<Transaction> transactionsToDel = tRepo.getWithdrawl_DepositByAccountID(acc.ID);
            //        foreach (Transaction t in transactionsToDel)
            //        {
            //            tRepo.deleteTransactions(t);
            //        }
            //    }
            //    else
            //    {
            //        aRepo.DelAccount(a);
            //  }
            //}
            //    List<Customer> softDeleteCustomers = cRepo.getSoftDeleteCustomers();
            //    foreach (Customer c in softDeleteCustomers)
            //    {
            //        List<Account> cAccounts = aRepo.getAllAccountsByCID(c.ID);
            //        if (cAccounts.Count == 0)
            //        {
            //            cRepo.deleteCustomer(c);
            //        }
            //    }

            //    TempData["Success"] = "Account deleted successfully";
            //    return RedirectToAction("ViewCustomers");
        }

    
        

        [Authorize(Roles = "Account-Executive, Customer-Executive")]

        // SELECTING ACCOUNT BY SSN OR CUSTOMER ID
        [HttpGet]
        public IActionResult ViewModel2()
        {
            ViewAccountDetailsVM model1 = new ViewAccountDetailsVM();
            return View("ViewModel2", model1);
        }

        [HttpPost]
        public IActionResult CID(ViewAccountDetailsVM model)
        {
            List<ViewAccountDetailsVM> a = aRepo.GetByCID2(model.CustomerID);
            List<ViewAccountDetailsVM> b = aRepo.GetBySSN(model.SSN);

            if (a == null && model.CustomerID != 0)
            {
                ViewBag.Error = $"No Accounts found with Customer ID {model.CustomerID}";
                return View("ViewModel2");
            }

            else if (model.CustomerID != 0)
            {
                return View(a);
            }

            else if (b == null && model.SSN != 0)
            {
                ViewBag.Error = $"No Accounts found with SSN {model.SSN}";
                return View("ViewModel2");
            }

            else if (model.SSN != 0)
            {
                return View(b);
            }

            else
                return View("ViewModel2");
        }


        //[Authorize(Roles = "Account-Executive, Customer-Executive")]
        //public IActionResult CustomerAcct()
        //{
        //    return View(aRepo.ViewCombo());
        //}



        [Authorize(Roles = "Account-Executive, Customer-Executive")]
        // SEARCHING BY CONDITIONS
        [HttpGet]
        public IActionResult Search()
        {
            //ViewAccountDetailsVM model1 = new ViewAccountDetailsVM();
            return View();
        }

        [HttpPost]
        public IActionResult Inputs(ViewAccountDetailsVM model)
        {
            List<ViewAccountDetailsVM> a = aRepo.GetByCID2(model.CustomerID);
            List<ViewAccountDetailsVM> b = aRepo.GetByName(model.Name);
            List<ViewAccountDetailsVM> c = aRepo.GetByType(model.AccountType);
            List<ViewAccountDetailsVM> d = aRepo.GetByAID(model.AccountID);

            if (a == null && model.CustomerID != 0)
            {
                ViewBag.Error = $"No Accounts found with Customer ID {model.CustomerID}";
                return View("Search");
            }

            else if (model.CustomerID != 0)
            {
                return View(a);
            }

            else if (b == null && model.Name != null)
            {
                ViewBag.Error = $"No Accounts found with Name {model.Name}";
                return View("Search");
            }

            else if (model.Name != null)
            {
                return View(b);
            }

            else if (c == null && model.AccountType != null)
            {
                ViewBag.Error = $"No Accounts found with Account Type {model.AccountType}";
                return View("Search");
            }


            else if (model.AccountType != null)
            {
                return View(c);
            }

            else if (d == null && model.AccountID != 0)
            {
                ViewBag.Error = $"No Accounts found with Account ID {model.AccountID}";
                return View("Search");
            }

            else if (model.AccountID != 0)
            {
                return View(d);
            }

            else
                return View("Search");
        }




























    //    public async Task<IActionResult> Index(
    //string sortOrder,
    //string currentFilter,
    //string searchString,
    //int? pageNumber)
    //    {
    //        ViewData["CurrentSort"] = sortOrder;
    //        ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
    //        ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

    //        if (searchString != null)
    //        {
    //            pageNumber = 1;
    //        }
    //        else
    //        {
    //            searchString = currentFilter;
    //        }

    //        ViewData["CurrentFilter"] = searchString;

    //        var students = from s in _context.Students
    //                       select s;
    //        if (!String.IsNullOrEmpty(searchString))
    //        {
    //            students = students.Where(s => s.LastName.Contains(searchString)
    //                                   || s.FirstMidName.Contains(searchString));
    //        }
    //        switch (sortOrder)
    //        {
    //            case "name_desc":
    //                students = students.OrderByDescending(s => s.LastName);
    //                break;
    //            case "Date":
    //                students = students.OrderBy(s => s.EnrollmentDate);
    //                break;
    //            case "date_desc":
    //                students = students.OrderByDescending(s => s.EnrollmentDate);
    //                break;
    //            default:
    //                students = students.OrderBy(s => s.LastName);
    //                break;
    //        }

    //        int pageSize = 3;
    //        return View(await PaginatedList<Student>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
    //    }
    }
}