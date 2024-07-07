using VMFramework.GameLogicArchitecture;

namespace TH.Spells
{
    public interface ISpellUnitConfig : IGameTypedGamePrefab
    {
        public SpellTargetType supportedTargetType { get; }
    }
}