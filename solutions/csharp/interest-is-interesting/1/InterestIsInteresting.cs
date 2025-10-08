static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        switch (balance)
        {
            case < 0:
                return 3.213f;
            case < 1000:
                return 0.5f;
            case < 5000:
                return 1.621f;
            default:
                return 2.475f;
        }
    }

    public static decimal Interest(decimal balance) => (balance / 100) * (decimal)InterestRate(balance);

    public static decimal AnnualBalanceUpdate(decimal balance) => balance + Interest(balance);

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int numberOfYears = 0;
        
        while (balance < targetBalance)
        {
            balance = AnnualBalanceUpdate(balance);
            numberOfYears++;
        }

        return numberOfYears;
    }
}
