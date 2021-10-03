using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransaction(int id);
        IEnumerable<Transaction> GetAllTransactionsForSpecificCustomer(int customerId);
    }
}
