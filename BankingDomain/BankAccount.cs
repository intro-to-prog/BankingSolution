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
            if (amountToWithdraw > _balance)
            {
                return;
            }
            else
            {
                _balance -= amountToWithdraw;
            }
        }

        public void Deposit(decimal amountToDeposit)
        {
            _balance += amountToDeposit;
        }
    }
}