using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AccountContext _context;

        public AccountsController(AccountContext context)
        {
            _context = context;
            Filldata();
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccount()
        {
            var data = await _context.Account.Include(p => p.PaymentList).ToListAsync();
            foreach (var account in data)
            {
                account.PaymentList = account.PaymentList.OrderByDescending(p => p.Date).ToList();
            }
            return data;

        }
        private void Filldata()
        {
            if (_context.Account.Any()) return;
            _context.Account.AddRange(new List<Account>()
            {   new Account { PaymentList = new List<Payment>(){
                new Payment { Id = 1, AccountId =1, Amount=2500.60, Date=DateTime.Now.AddDays(-24) },
                new Payment { Id = 2, AccountId =1, Amount=9450.65, Date=DateTime.Now.AddDays(-16) },
                new Payment { Id = 3, AccountId =1, Amount=2112.59, Date=DateTime.Now.AddDays(-12) },
                new Payment { Id = 4, AccountId =1, Amount=12812.50, Date=DateTime.Now.AddDays(-8) } },
                Id = 1, AccountNumber=1000001, Status="Closed", ReasonForClosing="No remaining balance", RemainingBalance=0},
                new Account { PaymentList = new List<Payment>(){
                new Payment { Id = 5, AccountId =2, Amount=4220.80, Date=DateTime.Now.AddDays(-21) },
                new Payment { Id = 6, AccountId =2, Amount=6500, Date=DateTime.Now.AddDays(-12) },
                new Payment { Id = 7, AccountId =2, Amount=8721.50, Date=DateTime.Now.AddDays(-9) } },
                Id = 2, AccountNumber=1000002, Status="Open", ReasonForClosing="", RemainingBalance=10082.42, },
                new Account { PaymentList = new List<Payment>(){
                new Payment { Id = 8, AccountId =3, Amount=6200, Date=DateTime.Now.AddDays(-19) },
                new Payment { Id = 9, AccountId =3, Amount=3560.70, Date=DateTime.Now.AddDays(-12) },
                new Payment { Id = 10, AccountId =3, Amount=8521, Date=DateTime.Now.AddDays(-3) }},
                Id = 3, AccountNumber=1000003, Status="Open", ReasonForClosing="", RemainingBalance=5450.25  },
                new Account { PaymentList = new List<Payment>(){
                new Payment { Id = 11, AccountId =4, Amount=800, Date=DateTime.Now.AddDays(-21)},
                new Payment { Id = 12, AccountId =4, Amount=2300, Date=DateTime.Now.AddDays(-8) } },
                Id = 4, AccountNumber=1000004, Status="Open", ReasonForClosing="", RemainingBalance=23460.74 },
                new Account { PaymentList = new List<Payment>(){
                new Payment { Id = 13, AccountId =5, Amount=17970.21, Date=DateTime.Now.AddDays(-19) },
                new Payment { Id = 14, AccountId =5, Amount=23056.85, Date=DateTime.Now.AddDays(-15) },
                new Payment { Id = 15, AccountId =5, Amount=8951.45, Date=DateTime.Now.AddDays(-7) },
                new Payment { Id = 16, AccountId =5, Amount=9440, Date=DateTime.Now.AddDays(-2) }, },
                Id = 5, AccountNumber=1000005, Status="Closed", ReasonForClosing="No remaining balance", RemainingBalance=0 }
            });

            _context.SaveChanges();
        }


        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var data = await _context.Account.Include(p => p.PaymentList).FirstOrDefaultAsync(p => p.Id == id);
            data.PaymentList = data.PaymentList.OrderByDescending(p => p.Date).ToList();
            return data;
        }
    }
}
