using PVZRTS.Properties;
using VMFramework.GameLogicArchitecture;
using VMFramework.Network;
using VMFramework.Timers;

namespace TH.Spells
{
    public interface ISpell : IVisualGameItem, IUUIDOwner, ICooldownOwner, ITimer
    {
        public ISpellOwner owner { get; }
        
        public void Cast(SpellCastInfo spellCastInfo);

        public void Abort(SpellAbortInfo spellAbortInfo);
    }
}