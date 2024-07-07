using Cysharp.Threading.Tasks;
using VMFramework.Core;
using VMFramework.GameLogicArchitecture;

namespace TH.Spells
{
    public interface ISpellUnit : IGameItem, IArgumentsResettable
    {
        public UniTask Examine(ISpell spell, SpellCastInfo spellCastInfo);

        public void Abort(SpellAbortInfo spellAbortInfo);
    }
}