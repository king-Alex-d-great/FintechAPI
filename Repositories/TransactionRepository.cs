using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities.Models;

namespace Repositories
{
    class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(OnlineBankApiContext context) : base(context){ }
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return GetAll().OrderBy(a => a.Id).ToList();
        }
        public Transaction GetTransaction(int id)
        {
            return Get(id);
        }
        public IEnumerable<Transaction> GetAllTransactionsForSpecificCustomer(int customerId)
        {
            return Find(a => a.CustomerId == customerId).OrderBy(a => a.TimeStamp).ThenBy(a => a.Id).ToList();
        }
    }
}
