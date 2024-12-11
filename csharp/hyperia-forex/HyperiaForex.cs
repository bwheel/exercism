using System;
using System.Diagnostics.CodeAnalysis;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }
    public static bool operator ==(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        ensureCurrencyEqual(lhs, rhs);
        return lhs.amount == rhs.amount;
    }

    public static bool operator !=(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        ensureCurrencyEqual(lhs, rhs);
        return !(lhs == rhs);
    }

    public static bool operator >(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        ensureCurrencyEqual(lhs, rhs);
        return lhs.amount > rhs.amount;
    }

    public static bool operator <(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        ensureCurrencyEqual(lhs, rhs);
        return lhs.amount < rhs.amount;
    }


    public static decimal operator +(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        ensureCurrencyEqual(lhs, rhs);
        return lhs.amount + rhs.amount;
    }

    public static decimal operator -(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        ensureCurrencyEqual(lhs, rhs);
        return lhs.amount - rhs.amount;
    }

    public static decimal operator *(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        ensureCurrencyEqual(lhs, rhs);
        return lhs.amount * rhs.amount;
    }

    public static decimal operator /(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        ensureCurrencyEqual(lhs, rhs);
        return lhs.amount / rhs.amount;
    }

    public static explicit operator double(CurrencyAmount currencyAmount) =>
        (double)currencyAmount.amount;

    public static implicit operator decimal(CurrencyAmount currencyAmount) =>
        currencyAmount.amount;

    public override bool Equals([NotNullWhen(true)] object obj)
    {
        if (obj == null)
            return false;
        CurrencyAmount currencyAmount = (CurrencyAmount)obj;
        return currencyAmount.amount.Equals(this.amount)
            && currencyAmount.currency.Equals(currency);
    }

    public override int GetHashCode()
    {
        return amount.GetHashCode() * currency.GetHashCode() * 57;
    }

    private static void ensureCurrencyEqual(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        if (lhs.currency != rhs.currency)
            throw new ArgumentException();
    }
}
