using System;
using System.Transactions;

enum AccountType
{
    Guest,
    User,
    Moderator,
}

[Flags]
enum Permission : byte
{
    Read = 0b0000_0001,
    Write = 0b0000_0010,
    Delete = 0b0000_0100,
    All = 0b0000_0111,
    None = 0b0000_000,
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
        => accountType switch
        {
            AccountType.Guest => Permission.Read,
            AccountType.User => Permission.Read | Permission.Write,
            AccountType.Moderator => Permission.All,
            _ => Permission.None,
        };

    public static Permission Grant(Permission current, Permission grant)
        => current | grant;

    public static Permission Revoke(Permission current, Permission revoke)
        => current & ~revoke;

    public static bool Check(Permission current, Permission check)
        => (current & check) == check;
}
