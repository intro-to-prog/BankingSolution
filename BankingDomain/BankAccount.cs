using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 5000;
        public decimal GetBalance()
        {
            return _balance;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            _balance -= amountToWithdraw;
        }
    }
}