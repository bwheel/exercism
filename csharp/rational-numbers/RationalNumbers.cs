using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this extension method.");
    }
}

public struct RationalNumber
{
    public int Numerator { get; }
    public int Denominator { get; }
    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        var numerator = r1.Numerator * r2.Denominator + r1.Denominator * r2.Numerator;
        var denominator = r1.Denominator * r2.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        var numerator = r1.Numerator * r2.Denominator - r1.Denominator * r2.Numerator;
        var denominator = r1.Denominator * r2.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        var numerator = r1.Numerator * r2.Numerator;
        var denominator = r1.Denominator * r2.Denominator;
        return new RationalNumber(numerator, denominator).Reduce();
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        var numerator = r1.Numerator * r2.Denominator;
        var denominator = r1.Denominator * r2.Numerator;
        return new RationalNumber(numerator, denominator).Reduce();
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(Numerator), Math.Abs(Denominator));
    }

    public RationalNumber Reduce()
    {
        var q = Denominator / Numerator;
        var d = Denominator / q;
        return new RationalNumber(q, d);
    }

    public RationalNumber Exprational(int power)
    {
        if (power >= 0)
        {
            var numerator = this.Numerator ^ power;
            var denominator = this.Denominator ^ power;
            return new RationalNumber(numerator, denominator);
        }
        else
        {

            var numerator = this.Denominator ^ Math.Abs(power);
            var denominator = this.Numerator ^ Math.Abs(power);
            return new RationalNumber(numerator, denominator);
        }
    }

    public double Expreal(int baseNumber)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}