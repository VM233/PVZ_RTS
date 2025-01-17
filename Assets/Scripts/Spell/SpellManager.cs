﻿using System;
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
        private static void CastInstantaneously(Guid uuid, SpellCastInfo spellCastInfo)
        {
            if (UUIDCoreManager.TryGetOwnerWithWarning(uuid, out ISpell spell))
            {
                spell.Cast(spellCastInfo);

                CooldownNetworkManager.ReconcileCooldownOnObservers(spell);
            }
        }

        [ServerRpc(RequireOwnership = false)]
        private void CastRequest(Guid uuid, SpellCastInfo spellCastInfo)
        {
            CastInstantaneously(uuid, spellCastInfo);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cast(ISpell spell, SpellCastInfo spellCastInfo)
        {
            if (instance.IsServerStarted)
            {
                CastInstantaneously(spell.uuid, spellCastInfo);
            }
            else
            {
                instance.CastRequest(spell.uuid, spellCastInfo);
            }
        }

        #endregion
    }
}
