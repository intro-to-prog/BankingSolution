using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 5000;
        private readonly ICanCalculateBonuses _bonusCalculator;
        private readonly INarcOnWithdrawals _narc;

        public BankAccount(ICanCalculateBonuses bonusCalculator, INarcOnWithdrawals narc)
        {
            _bonusCalculator = bonusCalculator;
            _narc = narc;
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if(amountToWithdraw <= 0)
            {
                throw new TransactionOutOfRangeException();
            }
            if (amountToWithdraw > _balance)
            {
                throw new OverdraftException();
            }
            else
            {
                // WTCYWYH
                // "Command" (Action)
                _narc.TellTheMan(this, amountToWithdraw);
                _balance -= amountToWithdraw;
            }
        }

        public void Deposit(decimal amountToDeposit)
        {
            // WTCYWYH
            // "Query" (Func)
            decimal bonus = _bonusCalculator.GetDepositBonusFor(_balance, amountToDeposit);
            _balance += amountToDeposit + bonus;
        }
    }
}