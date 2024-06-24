using Sirenix.OdinInspector;
using TH.Spells;
using UnityEngine;

namespace PVZRTS.Entities
{
    public abstract class SpellSelfCasterPlantController : PlantController, ISpellSelfCasterController
    {
        [field: Required]
        [field: SerializeField]
        public Transform castingTransform { get; private set; }

        Transform ISpellCasterController.casterCastingTransform => castingTransform;

        Transform ISpellOwnerController.ownerCastingTransform => castingTransform;
    }
}