using Exercism;

abstract class Character
{
    protected string _characterType;
    protected Character(string characterType)
    {
        _characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString() => $"Character is a {_characterType}";    
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (!target.Vulnerable()) return 6;

        return 10;
    }
}

class Wizard : Character
{
    private bool _spellPrepared = false;
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (!_spellPrepared) return 3;

        return 12;
    }

    public void PrepareSpell()
    {
        _spellPrepared = true;
    }

    public override bool Vulnerable() => !_spellPrepared;    
}
