using System;

public class Player
{
    public int RollDie()
        => new Random((int)DateTime.Now.Ticks).Next(1, 18);

    public double GenerateSpellStrength()
        => new Random((int)DateTime.Now.Ticks).NextDouble() * 100;
}
