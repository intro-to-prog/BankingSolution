namespace BankingDomain
{
    public interface ICanCalulateBonuses
    {
        decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit);
    }
}