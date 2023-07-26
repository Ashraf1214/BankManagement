using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCaseStudy13.Models
{
    public interface IAccountRepo
    {
        public List<Account> viewAccounts();
        public List<ViewAccountDetailsVM> getAccountDetails();

        public Account GetbyID(int id);
        public List<ViewAccountDetailsVM> GetByaccID(int id);
        public void update(Account a);

        public List<viewmodel3> Dates(viewmodelDate v);

        public Account GetByCID(int id);
        public List<Account> GetAccountsByCID(int id);
        public int AddAccount(Account a);
        public void DelAccount(Account a);

        public Transaction getTransferByaccountID(Account a);

        public List<ViewAccountDetailsVM> GetBySSN(int ssn);
        public List<ViewAccountDetailsVM> GetByCID2(int id);
        public List<ViewAccountDetailsVM> GetByType(string type);
        public List<ViewAccountDetailsVM> GetByName(string name);
        public List<ViewAccountDetailsVM> GetByAID(int aid);
        public List<ViewAccountDetailsVM> getByAccountID(int aid);

        //Only use these methods when you need to access the accounts which have been soft deleted
        public List<Account> getSoftDeleteAccounts();
        public List<Account> getSoftDeleteAccountsByCID(int id);
        public List<Account> getAllAccountsByCID(int id);
    }
}
