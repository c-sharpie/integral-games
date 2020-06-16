namespace Integral.Items
{
    internal class InventoryItem<Key> : Item<Key>
        where Key : notnull
    {
        internal InventoryItem(Key key) => Identity = key;

        public Key Identity { get; }
    }
}