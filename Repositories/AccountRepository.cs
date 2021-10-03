using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace Repositories
{
    class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(OnlineBankApiContext context) : base(context)
        {

        }

        public Account GetAccount(int id)
        {
            return Get(id);
        }

        public Account GetAccount(string accountNumber)
        {
            return Find(a => a.AccountNumber == accountNumber).FirstOrDefault();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return GetAll().OrderBy(a => a.Id).ToList();
        }
    }
}
