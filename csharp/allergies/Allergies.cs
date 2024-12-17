using System;
using System.Collections.Generic;
using System.Linq;

[Flags]
public enum Allergen : byte
{
    Eggs = 0b0000_0001,
    Peanuts = 0b0000_0010,
    Shellfish = 0b0000_0100,
    Strawberries = 0b0000_1000,
    Tomatoes = 0b0001_0000,
    Chocolate = 0b0010_0000,
    Pollen = 0b0100_0000,
    Cats = 0b1000_0000,
}

public class Allergies
{
    private int allergyMask;
    public Allergies(int mask) => allergyMask = mask;

    public bool IsAllergicTo(Allergen allergen) =>
        allergen switch
        {
            var a when (allergyMask & (byte)a) == (byte)Allergen.Eggs => true,
            var a when (allergyMask & (byte)a) == (byte)Allergen.Peanuts => true,
            var a when (allergyMask & (byte)a) == (byte)Allergen.Shellfish => true,
            var a when (allergyMask & (byte)a) == (byte)Allergen.Strawberries => true,
            var a when (allergyMask & (byte)a) == (byte)Allergen.Tomatoes => true,
            var a when (allergyMask & (byte)a) == (byte)Allergen.Chocolate => true,
            var a when (allergyMask & (byte)a) == (byte)Allergen.Pollen => true,
            var a when (allergyMask & (byte)a) == (byte)Allergen.Cats => true,
            _ => false,
        };


    private IEnumerable<Allergen> generateAllergenList()
    {
        foreach (Allergen value in Enum.GetValues(typeof(Allergen)))
            if (IsAllergicTo(value))
                yield return value;
    }
    public Allergen[] List() => generateAllergenList().ToArray();
}