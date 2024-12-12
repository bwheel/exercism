using System;

public static class CentralBank
{
    private static string handleException<TException>(Func<string> expression, string errMsg)
        where TException : Exception
    {
        try
        {
            return expression();
        }
        catch (TException)
        {
            return errMsg;
        }
    }
    public static string DisplayDenomination(long @base, long multiplier) =>
        handleException<OverflowException>(
            () => checked(@base * multiplier).ToString(),
            "*** Too Big ***"
            );

    public static string DisplayGDP(float @base, float multiplier) =>
        float.IsInfinity(@base * multiplier)
            ? "*** Too Big ***"
            : (@base * multiplier).ToString();

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier) =>
        handleException<OverflowException>(
            () => checked(salaryBase * multiplier).ToString(),
            "*** Much Too Big ***"
            );
}
