using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace FinalCaseStudy13.Models
{
    public class AccountRepo : IAccountRepo
    {
        context _db;
        public AccountRepo(context db)
        {
            _db = db;
        }


        // VIEWING ALL ACCOUNTS
        public List<Account> viewAccounts()
        {
            return _db.Account.Where(x => x.Account_Status != "SOFT DELETE").ToList();
        }


        //Get Account info by Account ID/ssn/Customer ID
        public Account GetbyID(int id)
        {
            return _db.Account.FirstOrDefault(x => x.Account_Status != "SOFT DELETE" && x.ID == id);
        }
        public List<ViewAccountDetailsVM> GetByaccID(int id)
        {
            var res = from Customer in _db.Customer
                      join Account in _db.Account on Customer.ID equals Account.Customer_ID
                      where Account.ID == id && Account.Account_Status != "Soft Delete"
                      select new ViewAccountDetailsVM { CustomerID = Customer.ID, Name = Customer.Name, AccountID = Account.ID, AccountType = Account.Account_Type, Balance = Account.Balance, SSN = (int)Customer.SSN, LastUpdated = Account.Status_Last_Updated, Status = Account.Account_Status };

            //bool isEmpty = !res.ToList().Any();
            //if (isEmpty)
            //    return null;
            //else
                return res.ToList();
        }

        //Method for depositing/Withdrawing and Transfer amount
        public void update(Account a)
        {
            _db.Entry(a).State = EntityState.Modified;
            _db.SaveChanges();
        }

        //Search a list of transactions by Starting date,Ending date,number of transaction and Account ID
        public List<viewmodel3> Dates(viewmodelDate v)
        {
            viewmodelDate c = new viewmodelDate();
            var Statement = from Account in _db.Account
                            join Transactions in _db.Transactions on Account.ID equals Transactions.Account_ID
                            where ((Transactions.Account_ID == v.ID) && (Account.Status_Last_Updated >= v.e && Account.Status_Last_Updated <= v.d) && (Account.Account_Status != "SOFT DELETE"))
                            select new viewmodel3 { a = Account, t = Transactions };
            var result = Statement
            .OrderByDescending(s => s.t.TranDate)
            .Take(v.count);
            return result.ToList();

        }

        

        public int AddAccount(Account a)
        {

            var count = (from b in _db.Account
                         where b.Customer_ID == a.Customer_ID
                         select b).Count();

            if (count == 2)
            {
                return 1; // TWO Account already exists
            }

            var x = (from b in _db.Account
                     where b.Customer_ID == a.Customer_ID
                     select b.Account_Type).FirstOrDefault();

            if (x == a.Account_Type)
            {
                return 2; // THIS type of account already exists 
            }

            else
            {
                _db.Account.Add(a);
                _db.SaveChanges();
                return (a.ID);
            }
        }

        public void DelAccount(Account a)
        {
            _db.Account.Remove(a);
            //_db.Transactions.Remove();
            _db.SaveChanges();
        }

        public Transaction getTransferByaccountID(Account a)
        {
            return _db.Transactions.FirstOrDefault(t => t.Transaction_Type == "Transfer" && ( t.Account_ID_2 == a.ID || t.Account_ID == a.ID));
        }

        public Account GetByCID(int id)
        {
            return _db.Account.FirstOrDefault(a => a.Customer_ID == id);
        }

        public List<Account> GetAccountsByCID(int id)
        {
            var res = from Account in _db.Account
                      where Account.Customer_ID == id && Account.Account_Status != "Soft Delete"
                      select Account;
            return res.ToList();
        }

        public List<ViewAccountDetailsVM> GetBySSN(int ssn)
        {
            var res = from Customer in _db.Customer
                      join Account in _db.Account on Customer.ID equals Account.Customer_ID
                      where Customer.SSN == ssn && Account.Account_Status != "Soft Delete"
                      select new ViewAccountDetailsVM { CustomerID = Customer.ID, Name = Customer.Name, AccountID = Account.ID, AccountType = Account.Account_Type, Balance = Account.Balance, SSN = (int)Customer.SSN, LastUpdated = Account.Status_Last_Updated, Status = Account.Account_Status } ;
            bool isEmpty = !res.ToList().Any();
            if (isEmpty)
                return null;
            else
                return res.ToList();
        }


        public List<ViewAccountDetailsVM> GetByCID2(int id)
        {
            var res = from Customer in _db.Customer
                      join Account in _db.Account on Customer.ID equals Account.Customer_ID
                      where Account.Customer_ID == id && Account.Account_Status != "Soft Delete"
                      select new ViewAccountDetailsVM { CustomerID = Customer.ID, Name = Customer.Name, AccountID = Account.ID, AccountType = Account.Account_Type, Balance = Account.Balance, SSN = (int)Customer.SSN, LastUpdated = Account.Status_Last_Updated, Status = Account.Account_Status };

            bool isEmpty = !res.ToList().Any();
            if (isEmpty)
                return null;
            else
                return res.ToList();
        }

        public List<Account> GetByCID3(int id)
        {
            var res = from Account in _db.Account
                      where Account.Customer_ID == id
                      select new Account { ID = Account.ID, Customer_ID = Account.Customer_ID, Account_Type = Account.Account_Type, Account_Status = Account.Account_Status, Status_Last_Updated = Account.Status_Last_Updated, Balance = Account.Balance };
            return res.ToList();
        }
        public List<ViewAccountDetailsVM> GetByName(string name)
        {
            var res = from Customer in _db.Customer
                      join Account in _db.Account on Customer.ID equals Account.Customer_ID
                      where Customer.Name == name && Account.Account_Status != "Soft Delete"
                      select new ViewAccountDetailsVM { CustomerID = Customer.ID, Name = Customer.Name, AccountID = Account.ID, AccountType = Account.Account_Type, Balance = Account.Balance, SSN = (int)Customer.SSN, LastUpdated = Account.Status_Last_Updated, Status = Account.Account_Status };
            bool isEmpty = !res.ToList().Any();
            if (isEmpty)
                return null;
            else
                return res.ToList();
        }


        public List<ViewAccountDetailsVM> GetByType(string type)
        {
            var res = from Customer in _db.Customer
                      join Account in _db.Account on Customer.ID equals Account.Customer_ID
                      where Account.Account_Type == type && Account.Account_Status != "Soft Delete"
                      select new ViewAccountDetailsVM { CustomerID = Customer.ID, Name = Customer.Name, AccountID = Account.ID, AccountType = Account.Account_Type, Balance = Account.Balance, SSN = (int)Customer.SSN, LastUpdated = Account.Status_Last_Updated, Status = Account.Account_Status };
            bool isEmpty = !res.ToList().Any();
            if (isEmpty)
                return null;
            else
                return res.ToList();
        }

        public List<ViewAccountDetailsVM> GetByAID(int aid)
        {
            var res = from Customer in _db.Customer
                      join Account in _db.Account on Customer.ID equals Account.Customer_ID
                      where Account.ID == aid && Account.Account_Status != "Soft Delete"
                      select new ViewAccountDetailsVM { CustomerID = Customer.ID, Name = Customer.Name, AccountID = Account.ID, AccountType = Account.Account_Type, Balance = Account.Balance, SSN = (int)Customer.SSN, LastUpdated = Account.Status_Last_Updated, Status = Account.Account_Status };
            bool isEmpty = !res.ToList().Any();
            if (isEmpty)
                return null;
            else
                return res.ToList();
        }
        public List<ViewAccountDetailsVM> getByAccountID(int aid)
        {

            var res = from Customer in _db.Customer
                      join Account in _db.Account on Customer.ID equals Account.Customer_ID
                      where Account.ID == aid && Account.Account_Status != "Soft Delete"
                      select new ViewAccountDetailsVM { CustomerID = Customer.ID, Name = Customer.Name, AccountID = Account.ID, AccountType = Account.Account_Type, Balance = Account.Balance, SSN = (int)Customer.SSN, LastUpdated = Account.Status_Last_Updated, Status = Account.Account_Status };
            return res.ToList();
        }
        // VIEWING COMBO OF ACCOUNT AND CUSTOMER 
        public List<ViewAccountDetailsVM> getAccountDetails()
        {
            var res = from Customer in _db.Customer
                      join Account in _db.Account on Customer.ID equals Account.Customer_ID
                      where Account.Account_Status != "Soft Delete"
                      select new ViewAccountDetailsVM { CustomerID = Customer.ID, Name = Customer.Name, AccountID = Account.ID, AccountType = Account.Account_Type, Balance = Account.Balance, SSN = (int)Customer.SSN, LastUpdated = Account.Status_Last_Updated, Status = Account.Account_Status };
            return res.ToList();
        }

        //Only use these methods when you need to access the accounts which have been soft deleted
        public List<Account> getSoftDeleteAccounts()
        {
            return _db.Account.Where(x => x.Account_Status == "SOFT DELETE").ToList();
        }
        public List<Account> getSoftDeleteAccountsByCID(int id)
        {
            return _db.Account.Where(x => x.Account_Status == "SOFT DELETE" && x.Customer_ID == id).ToList();
        }
        public List<Account> getAllAccountsByCID(int id)
        {
            return _db.Account.Where(x => x.Customer_ID == id).ToList();
        }

    }
}
