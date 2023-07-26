//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using FinalCaseStudy13.Models;
//using Microsoft.EntityFrameworkCore;

//namespace FinalCaseStudy13.Models
//{
//    public class TransactionsRepo:ITransactionsRepo
//    {
//            context _db;

//            public TransactionsRepo(context context)
//            {
//                _db = context;
//            }

//        public List<AccountTransaction> AccountAndTransactions()
//        {
//            throw new NotImplementedException();
//        }

//        public void update(Transactions t)
//        {
//            _db.Entry(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//            _db.SaveChanges();
//        }
//        public int add(Transactions t)
//        {
//            _db.Transactions.Add(t);
//            _db.SaveChanges();
//            return (t.ID);
//        }
//        public List<Transactions> viewTransactions()
//        {
//            return _db.Transactions.ToList();
//        }

//        public void deleteTransactions(Transactions t)
//        {
//            _db.Transactions.Remove(t);
//            _db.SaveChanges();
//            return;
//        }
//        public List<Transactions> getTransferByAccountID(int id)
//        {
//            return _db.Transactions.Where(x => (x.Account_ID == id || x.Account_ID_2 == id) && x.Transaction_Type == "Transfer").ToList();
//        }

//        public List<Transactions> getWithdrawl_DepositByAccountID(int accountID)
//        {
//            return _db.Transactions.Where(x => x.Account_ID == accountID && (x.Transaction_Type == "Withdrawl" || x.Transaction_Type == "Deposit")).ToList();
//        }

//        public List<Transactions> getNullTransfers()
//        {
//            var res = from T in _db.Transactions
//                      join A1 in _db.Account on T.Account_ID equals A1.ID 
//                      join A2 in _db.Account on T.Account_ID_2 equals A2.ID 
//                      where A1.Account_Status == "SOFT DELETE"  && A2.Account_Status == "SOFT DELETE"
//                      select T;
//            return res.ToList();
    
//            //return _db.Transactions.Join(
//            //    _db.Account,
//            //    T => T.Account_ID,
//            //    A1 => A1.ID,
//            //    (T, A1) => new Transactions{ ID = T.ID, Account_ID = T.Account_ID, Account_ID_2 = T.Account_ID_2, Transaction_Type = T.Transaction_Type, Amount = T.Amount }
//            //    )
//            //    .Join(
//            //    _db.Account,
//            //    T => T.Account_ID,
//            //    A2 => A2.ID,
//            //    (T, A2) => new Transactions{ ID = T.ID, Account_ID = T.Account_ID, Account_ID_2 = T.Account_ID_2, Transaction_Type = T.Transaction_Type, Amount = T.Amount }
//            //    ).Where().ToList();

//        }
//    }
//}
