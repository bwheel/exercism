using System;

abstract class Character
{
    protected string _characterType;
    protected Character(string characterType)
        => _characterType = characterType;

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
        => false;

    public override string ToString()
        => $"Character is a {_characterType}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior") { }

    public override int DamagePoints(Character target)
        => target.Vulnerable() ? 10 : 6;
}

class Wizard : Character
{
    private bool _isVulnerable = true;
    private bool _isSpellPrepared = false;
    public Wizard() : base("Wizard") { }

    public override int DamagePoints(Character target)
        => _isSpellPrepared ? 12 : 3;

    public override bool Vulnerable()
        => _isVulnerable;

    public void PrepareSpell()
    {
        _isVulnerable = false;
        _isSpellPrepared = true;
    }
}
