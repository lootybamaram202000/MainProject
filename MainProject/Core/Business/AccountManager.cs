using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.DataAccess;
using MainProject.Entities;

namespace MainProject.Core.Business
{
    public class AccountManager
    {
        private readonly AccountDAL _dal = new AccountDAL();

        public List<AccountModel> LoadAccounts(string peridPrefix)
        {
            return _dal.GetAllAccounts(peridPrefix);
        }

        public List<AccountModel> SearchAccounts(string searchText, string peridPrefix)
        {
            return _dal.SearchAccounts(searchText, peridPrefix);
        }

        public bool UpdateAccount(AccountModel account, string userID, string date, DateTime dateValue, int dateDig)
        {
            return _dal.UpdateAccount(account, userID, date, dateValue, dateDig);
        }

        public bool DeleteAccount(string acid, string userID, string date, DateTime dateValue, int dateDig)
        {
            return _dal.DeleteAccount(acid, userID, date, dateValue, dateDig);
        }
    }
}
