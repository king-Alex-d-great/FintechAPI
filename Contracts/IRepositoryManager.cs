using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public interface IRepositoryManager
    {
        public ICustomerRepository Customers { get;}
        public ITransactionRepository Transactions { get; }
        public IAccountRepository Accounts { get; }
        int Save();
    }
}
