using System;

public class Robot
{
    public string Name { get; private set; }

    public Robot()
    {
        Reset();
    }

    public void Reset()
    {
        Random r = new Random();
        //65 = A
        // 90 = Z
        char firstLetter = (char)r.Next(65, 90);
        char secondLetter = (char)r.Next(65, 90);
        int digits = r.Next(0, 999);
        Name =  firstLetter + secondLetter.ToString() + digits.ToString().PadLeft(3,'0');
    }
}