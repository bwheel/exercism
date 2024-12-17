using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Authenticator
{
    public Identity Admin { get; private set; }
    public IDictionary<string, Identity> GetDevelopers() => developers;
    public Authenticator(Identity admin) => Admin = admin;

    private readonly ReadOnlyDictionary<string, Identity> developers =
        new ReadOnlyDictionary<string, Identity>(
            new Dictionary<string, Identity>()
            {
                ["Bertrand"] = new Identity
                {
                    Email = "bert@ex.ism",
                    EyeColor = EyeColor.Blue
                },

                ["Anders"] = new Identity
                {
                    Email = "anders@ex.ism",
                    EyeColor = EyeColor.Brown,
                }
            });
    private static class EyeColor
    {
        public const string Blue = "blue";
        public const string Green = "green";
        public const string Brown = "brown";
        public const string Hazel = "hazel";
        public const string Grey = "grey";
    }
}

public struct Identity
{
    public string Email { get; internal set; }
    public string EyeColor { get; internal set; }
}
