using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace TH.Spells
{
    public sealed class GeneralSpell : Spell
    {
        private GeneralSpellConfig generalSpellConfig => (GeneralSpellConfig)gamePrefab;

        private bool isAborted;
        private SpellAbortInfo spellAbortInfo;

        public override async void Cast(SpellCastInfo spellCastInfo)
        {
            if (cooldown > 0)
            {
                if (isDebugging)
                {
                    Debug.LogWarning("Spell is on cooldown.");
                }

                return;
            }

            int completedCount = 0;
            isAborted = false;

            var operationToken = new SpellOperationToken()
            {
                Abort = () => isAborted = true,
                IsAborted = () => isAborted,
                GetAbortInfo = () => spellAbortInfo,
                Complete = () => completedCount++,
            };

            foreach (var spellUnitAction in generalSpellConfig.spellUnitActions)
            {
                spellUnitAction.Examine(this, spellCastInfo, operationToken);
            }

            await UniTask.WaitUntil(() =>
                isAborted || completedCount >= generalSpellConfig.spellUnitActions.Count);

            cooldown = generalSpellConfig.maxCooldown;
        }

        public override void Abort(SpellAbortInfo spellAbortInfo)
        {
            if (cooldown > 0)
            {
                return;
            }

            isAborted = true;
            this.spellAbortInfo = spellAbortInfo;
        }
    }
}