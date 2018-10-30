using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        return Enumerable
            .Range(0, max)
            .SelectMany( i => multiples.Select( mul => i % mul == 0 ? i : 0) ) 
            .Distinct()
            .Sum();
    }
}