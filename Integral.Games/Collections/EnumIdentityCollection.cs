using System;
using Integral.Functions;

namespace Integral.Collections
{
    public class EnumIdentityCollection<Key, Element> : IndexedCollection<Key, Element>
        where Key : notnull, Enum
        where Element : notnull
    {
        protected EnumIdentityCollection()
        {
            foreach (Key enumeration in EnumFunction.GetValues<Key>())
            {
                Add(enumeration, Create(enumeration));
            }
        }

        protected virtual Element Create(Key key) => Activator.CreateInstance<Element>();
    }
}