using System;
using Xunit;
using System.Threading.Tasks;
using System.Net;
using WebApplication1.Controllers;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace UnitTesting
{
    public class AccountsTest
    {

        private AccountContext _accountContext;
        private AccountsController _accountsController;

        public AccountsTest()
        {
           
            DbContextOptions<AccountContext> options = new DbContextOptionsBuilder<AccountContext>()
                .UseInMemoryDatabase("Account").Options;

            var _context = new AccountContext(options);
            _accountContext = _context;
            _accountsController = new AccountsController(_accountContext);

        }

        [Fact]
        public async void Test_AccountControllers()
        {
            var actionResult = await _accountsController.GetAccount();
            Assert.NotNull(actionResult);
            Assert.Equal(5,actionResult.Value.Count());
            
        }
    }
}

