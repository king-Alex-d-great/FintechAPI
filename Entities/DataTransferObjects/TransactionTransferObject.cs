using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enumerators;

namespace Entities.DataTransferObjects
{
    public class TransactionTransferObject
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }        
        public TransactionMode TransactionMode { get; set; }
        public TransactionType TransactionType { get; set; }        
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsSuccessful { get; set; }
        public string SenderAccount { get; set; }
        public string ReceiverAccount { get; set; }
    }
}
