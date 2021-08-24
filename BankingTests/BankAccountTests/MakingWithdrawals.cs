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

        // Replicate the bad behavior (this should pass when you start, demonstrating where the problem is)
        [Fact]
        public void OverdraftAllowed()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToWithrdaw = openingBalance + 1;

            account.Withdraw(amountToWithrdaw);

            Assert.Equal(-1, account.GetBalance());
        }

        [Fact]
        public void OverdraftNotAllowed()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToWithrdaw = openingBalance + 1;

            account.Withdraw(amountToWithrdaw);

            Assert.Equal(openingBalance, account.GetBalance());
        }

        [Fact]
        public void CanTakeAllTheMoney()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            account.Withdraw(openingBalance);

            Assert.Equal(0, account.GetBalance());
        }
    }
}
