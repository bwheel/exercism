using System;
using System.Collections.Generic;
using System.Linq;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if(!numbers.Any())
            throw new ArgumentException("numbers must contain digits", nameof(numbers));
        if(numbers.Length < sliceLength)
            throw new ArgumentException("Slice length is too large", nameof(sliceLength));
        if(sliceLength <= 0)
            throw new ArgumentException("Slice length must be a non-zero positive number", nameof(sliceLength));
        return Enumerable.Range(0,numbers.Length + 1 - sliceLength).Select(i => numbers.Substring(i, sliceLength)).ToArray();
    }
}