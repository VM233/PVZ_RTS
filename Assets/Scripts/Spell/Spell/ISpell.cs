using PVZRTS.Properties;
using VMFramework.GameLogicArchitecture;
using VMFramework.Network;
using VMFramework.Timers;

namespace TH.Spells
{
    public interface ISpell : IVisualGameItem, IUUIDCooldownProvider, ICooldownOwner, ITimer
    {
        public ISpellOwner owner { get; }

        public void SetOwner(ISpellOwner owner);

        public void SetToMaxCooldown();
        
        public void Cast(SpellCastInfo spellCastInfo);
        
        public bool IsCasting();

        public void Abort(SpellAbortInfo spellAbortInfo);
        
        public bool IsAborted();
    }
}