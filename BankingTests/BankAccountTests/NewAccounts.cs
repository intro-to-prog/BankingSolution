using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace BankingTests
{
    public class NewAccounts
    {
        [Fact]
        public void NewAccountsHaveProperBalance()
        {
            var account = new BankAccount();

            decimal openingBalance = account.GetBalance();

            Assert.Equal(5000M, openingBalance);
        }
    }
}
