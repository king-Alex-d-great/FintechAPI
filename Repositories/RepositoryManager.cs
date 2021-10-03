using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        public RepositoryManager(OnlineBankApiContext context)
        {
            _context = context;
        }
        private ICustomerRepository _customerRepo;

        private ITransactionRepository _transactionRepo ;

        private IAccountRepository _accountRepo ;

        private readonly OnlineBankApiContext _context;

        public ICustomerRepository Customers
        {
            get
            {
                return _customerRepo ??= new CustomerRepository(_context);
            }
        }

       public ITransactionRepository Transactions
        {
            get
            {
                return _transactionRepo ??= new TransactionRepository(_context);
            }
        }

        public IAccountRepository Accounts
        {
            get
            {
                return _accountRepo ??= new AccountRepository(_context);
            }
        }

        public int Save() => _context.SaveChanges();
        
    }
}
