using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests.GoldAccountTests
{
    public class GoldAccountDepositBonuses
    {
        [Fact]
        public void GoldAccountsGetBonusesOnDeposits()
        {
            // Establish Context
            var account = new BankAccount();
            account.Type = AccountType.Gold;
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100M;

            // When
            account.Deposit(amountToDeposit);
            
            // Different Then
            Assert.Equal(openingBalance + amountToDeposit + 10M, account.GetBalance());
        }
    }
}
