using System;
using System.Linq;
using System.Text;
public static class Raindrops
{
    public static string Convert(int number)
    {
        var divisibles = Enumerable
            .Range(1, number )
            .Where( i => number % i == 0);               
                
        if(divisibles.Any( i => i ==3 || i == 5 || i == 7))
        {
            return divisibles
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
        }
        else
        {
            return divisibles
                    .Last()
                    .ToString();
        }
    }
}