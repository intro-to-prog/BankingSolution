using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests.GoldAccountTests
{
    public class GoldAccountsGetBonuses
    {
        [Fact]
        public void BonusOnDeposit()
        {
            // Given (Estabilish Context)
            var account = new GoldAccount();
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100M;

            account.Deposit(amountToDeposit);

            Assert.Equal(openingBalance + amountToDeposit + 10M, account.GetBalance());
        }
    }
}
