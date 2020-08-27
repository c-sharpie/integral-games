using System;
using Integral.Functions;

namespace Integral.Collections
{
    public class EnumeratedCollection<Key, Element> : IndexedCollection<Key, Element>
        where Key : notnull, Enum
        where Element : notnull
    {
        protected EnumeratedCollection()
        {
            foreach (Key enumeration in EnumFunction.GetValues<Key>())
            {
                Add(enumeration, Create(enumeration));
            }
        }

        protected virtual Element Create(Key key) => Activator.CreateInstance<Element>();
    }
}