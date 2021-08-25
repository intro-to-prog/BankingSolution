using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests.BankAccountTests
{
    public class BankAccountBonusCalculatorInteractionTests
    {

        [Fact]
        public void Watermelon()
        {
            var account = new BankAccount(new StubbedBonusCalculator());
            var openingBalance = account.GetBalance();
            var amountToDeposit = 53.25M;

            account.Deposit(amountToDeposit);

            Assert.Equal(openingBalance + amountToDeposit + 42M, account.GetBalance());

        }
    }

    public class StubbedBonusCalculator : ICanCalulateBonuses
    {
        public decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit)
        {
            return balance == 5000M && amountToDeposit == 53.25M ? 42 : 0;
        }
    }
}
