using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Многопоточность
{
    class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public DateTime Timestamp { get; set; }
        public string Status { get; set; }

        public Transaction(int id, decimal amount, string type, string status)
        {
            Id = id;
            Amount = amount;
            Type = type;
            Timestamp = DateTime.Now;
            Status = status;
        }
        public override string ToString()
        {
            return $"[{Timestamp:yyyy-MM-dd HH:mm:ss}] {Type}: ${Amount:F2}, Status: {Status}\n";
        }
    }
}
