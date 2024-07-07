using Cysharp.Threading.Tasks;
using VMFramework.GameLogicArchitecture;

namespace TH.Spells
{
    public abstract class SpellUnit : GameItem, ISpellUnit
    {
        public abstract void ResetArguments();
        
        public abstract UniTask Examine(ISpell spell, SpellCastInfo spellCastInfo);

        public abstract void Abort(SpellAbortInfo spellAbortInfo);
    }
}