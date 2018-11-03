using System;
using System.Linq;
using System.Text;
public static class Raindrops
{
    public static string Convert(int number)
    {
        var results = Enumerable
            .Range(1, number )
            .Where( i => number % i == 0)
            .Aggregate( string.Empty, ( s, i ) =>
                    {
                        if( i == 3)
                        {
                            return s + "Pling";
                        }

                        if( i == 5)
                        {
                            return s + "Plang";
                        }

                        if( i == 7)
                        {
                            return s + "Plong";
                        }
                        return s;
                    });       
                
        return !string.IsNullOrWhiteSpace(results) ? results : number.ToString();        
    }
}