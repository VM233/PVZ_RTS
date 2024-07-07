using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;
using VMFramework.Core;
using VMFramework.GameLogicArchitecture;

namespace TH.Spells
{
    public sealed class GeneralSpell : Spell
    {
        private GeneralSpellConfig generalSpellConfig => (GeneralSpellConfig)gamePrefab;
        
        [ShowInInspector]
        private bool isAborted;
        [ShowInInspector]
        private bool isCasting;

        [ShowInInspector]
        private readonly List<ISpellUnit> spellUnits = new();
        private readonly List<UniTask> spellUnitTasks = new();

        protected override void OnFirstCreated()
        {
            base.OnFirstCreated();

            foreach (var spellUnitID in generalSpellConfig.spellUnitsID)
            {
                var spellUnit = IGameItem.Create<ISpellUnit>(spellUnitID);
                
                spellUnits.Add(spellUnit);
            }
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            
            spellUnits.ResetArguments();
        }

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

            isAborted = false;
            isCasting = true;

            foreach (var spellUnitAction in spellUnits)
            {
                spellUnitTasks.Add(spellUnitAction.Examine(this, spellCastInfo));
            }

            await UniTask.WhenAll(spellUnitTasks);

            cooldown = generalSpellConfig.maxCooldown;
            isAborted = false;
            isCasting = false;
        }

        public override void Abort(SpellAbortInfo spellAbortInfo)
        {
            if (isCasting == false)
            {
                return;
            }

            isAborted = true;

            foreach (var spellUnit in spellUnits)
            {
                spellUnit.Abort(spellAbortInfo);
            }
        }

        public override bool IsCasting() => isCasting;

        public override bool IsAborted() => isAborted;
    }
}