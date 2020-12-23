namespace Adonai.Structures
{
    public interface Edge<Key>
        where Key : notnull
    {
        Node<Key> Node { get; }

        float Weight { get; }
    }
}