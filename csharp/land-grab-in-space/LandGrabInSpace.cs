using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
    public override bool Equals([NotNullWhen(true)] object obj)
    {
        Coord c = (Coord)obj;
        return c.X == X && c.Y == Y;
    }
}

public struct Plot
{
    public Coord TopLeft { get; set; }
    public Coord TopRight { get; set; }
    public Coord BottomLeft { get; set; }
    public Coord BottomRight { get; set; }
    public bool IsStakeClaimed { get; set; }

    public Plot(Coord topLeft, Coord topRight, Coord bottomLeft, Coord bottomRight)
    {
        TopLeft = topLeft;
        TopRight = topRight;
        BottomLeft = bottomLeft;
        BottomRight = bottomRight;
    }
    public int GetLongestSide() =>
        new int[]
        {
            Math.Abs(TopLeft.X - TopRight.X),
            Math.Abs(TopLeft.Y - BottomLeft.Y),
            Math.Abs(BottomLeft.X - BottomRight.X),
            Math.Abs(BottomRight.Y - TopRight.Y)
        }.Max();

    public override bool Equals([NotNullWhen(true)] object obj)
    {
        Plot p = (Plot)obj;
        return p.TopRight.Equals(TopRight)
            && p.TopLeft.Equals(TopLeft)
            && p.BottomLeft.Equals(BottomLeft)
            && p.BottomRight.Equals(BottomRight);
    }
}


public class ClaimsHandler
{
    private List<Plot> m_claims = new List<Plot>();
    public void StakeClaim(Plot plot)
    {
        if (!IsClaimStaked(plot))
            m_claims.Add(plot);
    }

    public bool IsClaimStaked(Plot plot) =>
        m_claims.Where(p => p.Equals(plot)).Any();

    public bool IsLastClaim(Plot plot) =>
        m_claims.Last().Equals(plot);

    public Plot GetClaimWithLongestSide()
    {
        var maxPlot = m_claims.First();
        foreach (var plot in m_claims.Skip(1))
        {
            if (plot.GetLongestSide() > maxPlot.GetLongestSide())
            {
                maxPlot = plot;
            }
        }
        return maxPlot;
    }
}
