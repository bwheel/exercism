using System;
using System.Collections.Generic;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if(firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException();
        }

        int hammingCount = 0;
        for( int i = 0; i < firstStrand.Length; i++)
        {
            hammingCount = (firstStrand[i] != secondStrand[i]) ? hammingCount + 1: hammingCount;
        }
        return hammingCount;
    }
}