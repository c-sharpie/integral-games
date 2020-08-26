namespace Integral.Abilities
{
    internal sealed class PassiveAbility<Key> : ActiveAbility<Key>
        where Key : notnull
    {
        internal PassiveAbility(Key key) : base(key)
        {
        }
    }
}