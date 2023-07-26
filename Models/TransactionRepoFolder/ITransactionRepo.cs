using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCaseStudy13.Models
{
    public interface ITransactionRepo
    {
        public List<AccountTransaction> AccountAndTransactions();
        public void update(Transaction t);
        public int add(Transaction t);
        public void deleteTransactions(Transaction t);
        public List<Transaction> viewTransactions();
        public List<Transaction> getTransferByAccountID(int id);
        public List<Transaction> getNullTransfers();
        public List<Transaction> getWithdrawl_DepositByAccountID(int accountID);

    }
}
