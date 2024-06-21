using System;
using Sirenix.OdinInspector;

namespace TH.Spells
{
    [Flags]
    public enum SpellTargetType
    {
        None = 0,

        Entities = 1,

        Direction = 2,

        Position = 4,

        DirectionAndPosition = Direction | Position,
    }
}