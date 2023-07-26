using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalCaseStudy13.Models;

namespace FinalCaseStudy13.Controllers
{
    public class TransactionController : Controller
    {
        ITransactionRepo tRepo;
        IAccountRepo aRepo;
        public TransactionController(ITransactionRepo trepo, IAccountRepo arepo)
        {
            tRepo = trepo;
            aRepo = arepo;
        }

        public IActionResult ViewTransactions()
        {
            return View(tRepo.viewTransactions());
        }

        [HttpGet]
        public IActionResult AddTransaction()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTransaction(Transaction t)
        {
            if (ModelState.IsValid)
            {
                tRepo.add(t);
                return RedirectToAction("viewTransaction");
            }
            else
                return View();
        }

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
            Account obj = aRepo.GetbyID((int)v.t.Account_ID_2);
            v.a.Status_Last_Updated = DateTime.Today;

            viewmodel3 s = new viewmodel3();
            s.a = obj;

            if (ModelState.IsValid)
            {
                if (v.a.Balance >= v.t.Amount && s.a != null)
                {
                    v.a.Balance = v.a.Balance - v.t.Amount;
                    s.a.Balance = s.a.Balance + v.t.Amount;
                    tRepo.add(v.t);
                    aRepo.update(v.a);
                    ViewBag.Success = "Transfer Successful";
                    return RedirectToAction("ViewAccounts");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid input(s)";
                    return View("Transfer");
                }
            }
            else
                return View(v);

        }

        //View Account Statement by Account ID and Date range
        [HttpGet]
        public IActionResult SearchSbyID()
        {
            viewmodelDate d = new viewmodelDate();
            return View(d);
        }
        [HttpPost]
        public IActionResult ViewStatementbyAccID(viewmodelDate obj)
        {
            return View(aRepo.Dates(obj));
        }

        //Action Method for depositing amount
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

        //Action Method for withdrawing amount
        [HttpGet]
        public IActionResult Withdraw(int id)
        {
            Account obj = aRepo.GetbyID(id);
            viewmodel3 v = new viewmodel3();
            v.a = obj;
            return View(v);
        }
        [HttpPost]
        public IActionResult Withdraw(viewmodel3 v)
        {
            v.t.Account_ID = v.a.ID;
            v.t.Transaction_Type = "Withdrawl";
            v.t.Account_ID_2 = v.a.ID;
            v.a.Status_Last_Updated = DateTime.Today;
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
    }
}
