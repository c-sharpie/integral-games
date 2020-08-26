namespace Integral.Collections
{
    public class WeightedCollection<Node> : ListedCollection<(Node, float)>, PriorityCollection<Node, float>
        where Node : notnull
    {
        public bool Add(Node node, float weight)
        {
            Add((node, weight));
            if (Count > 1)
            {
                int position = Count - 1;
                int parent = position / 2;
                while (position > 0 && this[parent].Item2 > this[position].Item2)
                {
                    Swap(position, parent);
                    position = parent;
                    parent = (position - 1) / 2;
                }
            }

            return true;
        }

        public bool Remove(out Node node)
        {
            if (Count > 0)
            {
                node = this[0].Item1;
                int lastIndex = Count - 1;
                Swap(0, lastIndex);
                RemoveAt(lastIndex);
                int position = 0;
                while (true)
                {
                    int largest = default;
                    int index = 2 * position;

                    int left = index + 1;
                    if (left < Count && this[left].Item2 < this[position].Item2)
                    {
                        largest = left;
                    }

                    int right = index + 2;
                    if (right < Count && this[right].Item2 < this[largest].Item2)
                    {
                        largest = right;
                    }

                    if (largest == 0)
                    {
                        break;
                    }

                    Swap(position, largest);
                    position = largest;
                }

                return true;
            }

            node = default!;
            return false;
        }
    }
}