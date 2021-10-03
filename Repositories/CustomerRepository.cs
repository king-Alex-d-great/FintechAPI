using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace Repositories
{
    class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OnlineBankApiContext context): base(context)
        {

        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return GetAll().OrderBy(C => C.Id).ToList();
        }

        public Customer GetCustomer(int id)
        {
            return Get(id);
        }

        public Customer GetCustomerWithAccountId(int accountId)
        {
            return Find(a => a.AccountId == accountId).FirstOrDefault();
        }
    }
}
