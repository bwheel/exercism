using System;
using System.Collections.Generic;
using System.Linq;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    public override bool Equals(object obj)
    {
        FacialFeatures f = obj as FacialFeatures;
        return f != null && f.EyeColor.Equals(EyeColor) && f.PhiltrumWidth == PhiltrumWidth;
    }

    public override int GetHashCode()
    {
        return EyeColor.GetHashCode() * PhiltrumWidth.GetHashCode() * 57;
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    public override bool Equals(object obj)
    {
        Identity i = obj as Identity;
        return i != null && i.Email.Equals(Email) && i.FacialFeatures.Equals(FacialFeatures);
    }
    public override int GetHashCode()
    {
        return Email.GetHashCode() * FacialFeatures.GetHashCode() * 57;
    }
}

public class Authenticator
{
    private static readonly Identity s_adminIdentity = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
         => faceA.Equals(faceB);

    private HashSet<Identity> _registeredIdentities = new HashSet<Identity>();

    public bool IsAdmin(Identity identity)
        => s_adminIdentity.Equals(identity);

    public bool Register(Identity identity)
    {
        if (!IsRegistered(identity))
        {
            _registeredIdentities.Add(identity);
            return true;
        }
        return false;
    }

    public bool IsRegistered(Identity identity)
        => _registeredIdentities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB)
        => identityA == identityB;
}
