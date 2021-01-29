using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Account
    {
        [Key]
        public int  Id { get; set; }
        public int AccountNumber { get; set; }
        public string Status { get; set; }
        public string ReasonForClosing { get; set; }
        public List<Payment> PaymentList { get; set; }
        public double RemainingBalance { get; set; }


    }
}
