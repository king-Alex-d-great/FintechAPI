using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Enumerators;

namespace Entities.Models
{
    public class Transaction
    {
        public int Id { get; set; }  
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public TransactionMode TransactionMode { get; set; }
        public TransactionType TransactionType { get; set; }
        [Column(TypeName = "decimal(38,2)")]
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsSuccessful { get; set; }
        public string SenderAccount { get; set; }
        public string ReceiverAccount{ get; set; }
    }
}
