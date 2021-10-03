using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models
{
    public class Customer
    {

        public int Id { get; set; }
        public DateTime Birthday { get; set; }
        public int AccountId { get; set; }
        [ForeignKey(nameof(AccountId))]
        public Account Account { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
