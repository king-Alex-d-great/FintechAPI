using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enumerators;

namespace Entities.DataTransferObjects
{
    public class AccountTransferObject
    {

        public int Id { get; set; }
      
        public string AccountNumber { get; set; }
       
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public AccountType AccountType { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
    }
}
