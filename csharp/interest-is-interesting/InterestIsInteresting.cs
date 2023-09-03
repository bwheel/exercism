using System;
using System.Collections;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
        => balance switch
        {
            decimal d when d < 0m => 3.213f,
            decimal d when d < 1000m => 0.5f,
            decimal d when d < 5000m => 1.621f,
            _ => 2.475f,
        };

    public static decimal Interest(decimal balance) => (decimal)InterestRate(balance) * balance / 100;

    public static decimal AnnualBalanceUpdate(decimal balance) => Interest(balance) + balance;

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;
        while (balance < targetBalance)
        {
            years++;
            balance = AnnualBalanceUpdate(balance);
        }
        return years;
    }
}
