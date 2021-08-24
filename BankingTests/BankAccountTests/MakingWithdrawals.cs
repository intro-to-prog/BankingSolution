using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests
{
    public class MakingWithdrawals
    {
        [Fact]
        public void WithdrawalsDecreaseBalance()
        {
            // Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 10M;
            // When
            account.Withdraw(amountToWithdraw);
            // Then
            Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
        }
    }
}
