using System;

namespace Integral.Enumerations
{
    [Flags]
    public enum AccountFlags : byte
    {
        Standard = 0,

        Premium = 1,

        Administrator = 2,

        Warning = 4,

        Banned = 8
    }
}