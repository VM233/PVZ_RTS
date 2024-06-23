using System.Runtime.CompilerServices;
using FishNet.Object;
using PVZRTS.GameCore;
using VMFramework.Network;
using VMFramework.Procedure;

namespace TH.Spells
{
    [ManagerCreationProvider(nameof(GameManagerType.Spell))]
    public sealed class SpellManager : UUIDManager<SpellManager, ISpell>
    {
        #region Cast

        [Server]
        private static void CastInstantaneously(string uuid, SpellCastInfo spellCastInfo)
        {
            if (UUIDCoreManager.TryGetOwnerWithWarning(uuid, out ISpell spell))
            {
                spell.Cast(spellCastInfo);

                CooldownNetworkManager.ReconcileCooldownOnObservers(spell);
            }
        }

        [ServerRpc(RequireOwnership = false)]
        private void CastRequest(string uuid, SpellCastInfo spellCastInfo)
        {
            CastInstantaneously(uuid, spellCastInfo);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cast(ISpell spell, SpellCastInfo spellCastInfo)
        {
            if (_instance.IsServerStarted)
            {
                CastInstantaneously(spell.uuid, spellCastInfo);
            }
            else
            {
                _instance.CastRequest(spell.uuid, spellCastInfo);
            }
        }

        #endregion
    }
}
