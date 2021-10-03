using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
   public class CustomerTransferObject
    {
        public int Id { get; set; }
        public DateTime Birthday { get; set; }
        public int AccountId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "King Alex";
        public string UpdatedBy { get; set; } = "King Alex";
    }
}
