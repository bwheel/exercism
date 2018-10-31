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
    private int numerator;
    private int denominator;

    public RationalNumber(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;
    }

    public RationalNumber Add(RationalNumber r)
    {
        return this + r;        
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber((r1.numerator * r2.denominator + r2.numerator * r1.denominator), (r1.denominator * r2.denominator));
    }

    public RationalNumber Sub(RationalNumber r)
    {
        return this - r;
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber( (r1.numerator * r2.denominator - r2.numerator * r1.denominator), (r1.denominator * r2.denominator) );
    }

    public RationalNumber Mul(RationalNumber r)
    {
        return this * r;
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.numerator * r1.denominator, r2.numerator * r2.denominator);
    }

    public RationalNumber Div(RationalNumber r)
    {
        return this / r;
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        int denominator = r1.denominator * r2.numerator;
        if( denominator < 0)
            throw new ArgumentException();
        return new RationalNumber( (r1.numerator * r2.denominator), denominator);
    }

    public RationalNumber Abs()
    {
        numerator = Math.Abs(numerator);
        denominator = Math.Abs(denominator);
        return this;
    }

    public RationalNumber Reduce()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public RationalNumber Exprational(int power)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public double Expreal(int baseNumber)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}