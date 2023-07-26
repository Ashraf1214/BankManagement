using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinalCaseStudy13.Models
{
    public class TransactionRepo:ITransactionRepo
    {
            context _db;

            public TransactionRepo(context context)
            {
                _db = context;
            }

        public List<AccountTransaction> AccountAndTransactions()
        {
            throw new NotImplementedException();
        }


        public void update(Transaction t)
        {
            _db.Entry(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
        }
        public int add(Transaction t)
        {
            _db.Transactions.Add(t);
            _db.SaveChanges();
            return (t.ID);
        }
        public List<Transaction> viewTransactions()
        {
            return _db.Transactions.ToList();
        }

        public void deleteTransactions(Transaction t)
        {
            _db.Transactions.Remove(t);
            _db.SaveChanges();
            return;
        }
        public List<Transaction> getTransferByAccountID(int id)
        {
            return _db.Transactions.Where(x => (x.Account_ID == id || x.Account_ID_2 == id) && x.Transaction_Type == "Transfer").ToList();
        }

        public List<Transaction> getWithdrawl_DepositByAccountID(int accountID)
        {
            return _db.Transactions.Where(x => x.Account_ID == accountID && (x.Transaction_Type == "Withdrawl" || x.Transaction_Type == "Deposit")).ToList();
        }

        public List<Transaction> getNullTransfers()
        {
            var res = from T in _db.Transactions
                      join A1 in _db.Account on T.Account_ID equals A1.ID 
                      join A2 in _db.Account on T.Account_ID_2 equals A2.ID 
                      where A1.Account_Status == "SOFT DELETE"  && A2.Account_Status == "SOFT DELETE"
                      select T;
            var statement = res
                .OrderByDescending(s => s.TranDate);
            return statement.ToList();
        }
    }
}
