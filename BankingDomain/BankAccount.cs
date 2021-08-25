using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 5000;
        private readonly ICanCalulateBonuses _bonusCalculator;
        private readonly INarcOnWithdrawals _narc;

        public BankAccount(ICanCalulateBonuses bonusCalculator, INarcOnWithdrawals narc)
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
            if (amountToWithdraw > _balance)
            {
                throw new OverdraftException();
            }
            else
            {
                // WTCYWYH
                _narc.TellTheMan(this, amountToWithdraw);
                _balance -= amountToWithdraw;
            }
        }

        public void Deposit(decimal amountToDeposit)
        {
            // WTCYWYH
            decimal bonus = _bonusCalculator.GetDepositBonusFor(_balance, amountToDeposit);
            _balance += amountToDeposit + bonus;
        }
    }
}