using System;

public static class Grains
{
    public static ulong Square(int n)
    {
        if(n < 1 || n > 64)
        {
            throw new ArgumentOutOfRangeException();
        }
        return (ulong)1L  << (n-1);
    }

    public static ulong Total()
    {
        return 18446744073709551615UL;
    }
}