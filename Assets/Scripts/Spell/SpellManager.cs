using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using PVZRTS.GameCore;
using VMFramework.Network;
using VMFramework.Procedure;

namespace TH.Spells
{
    [ManagerCreationProvider(nameof(GameManagerType.Spell))]
    public sealed class SpellManager : UUIDManager<SpellManager, ISpell>
    {
        public override void OnStartServer()
        {
            base.OnStartServer();
            
            OnRegisterEvent += OnRegisterSpell;
            OnUnregisterEvent += OnUnregisterSpell;
        }

        public override void OnStopServer()
        {
            base.OnStopServer();
            
            OnRegisterEvent -= OnRegisterSpell;
            OnUnregisterEvent -= OnUnregisterSpell;
        }

        private void OnRegisterSpell(ISpell spell)
        {
            spell.OnObservedEvent += OnObserved;
        }

        private void OnUnregisterSpell(ISpell spell)
        {
            spell.OnObservedEvent -= OnObserved;
        }
        
        private void OnObserved(IUUIDOwner owner, bool isDirty, NetworkConnection connection)
        {
            ReconcileCooldown(connection, owner.uuid, ((ISpell)owner).cooldown);
        }

        #region Update

        [Server]
        private static void ReconcileCooldownOnObservers(ISpell spell)
        {
            foreach (var observer in spell.GetObservers())
            {
                ReconcileCooldownOnTargetObserve(observer, spell);
            }
        }

        [Server]
        private static void ReconcileCooldownOnTargetObserve(int observer, ISpell spell)
        {
            if (observer.TryGetConnectionWithWarning(out var connection) == false)
            {
                return;
            }

            if (connection.IsHost)
            {
                return;
            }

            _instance.ReconcileCooldown(connection, spell.uuid, spell.cooldown);
        }

        [TargetRpc]
        private void ReconcileCooldown(NetworkConnection connection, string uuid, float cooldown)
        {
            if (UUIDCoreManager.TryGetOwnerWithWarning(uuid, out ISpell spell))
            {
                spell.cooldown = cooldown;
            }
        }

        #endregion

        #region Cast

        [Server]
        private static void CastInstantaneously(string uuid, SpellCastInfo spellCastInfo)
        {
            if (UUIDCoreManager.TryGetOwnerWithWarning(uuid, out ISpell spell))
            {
                spell.Cast(spellCastInfo);

                ReconcileCooldownOnObservers(spell);
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
