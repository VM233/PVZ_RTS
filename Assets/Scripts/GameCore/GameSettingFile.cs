using PVZRTS.Damage;
using PVZRTS.Entities;
using PVZRTS.UI;
using TH.Spells;
using VMFramework.GameLogicArchitecture;

namespace PVZRTS.GameCore
{
    public class GameSettingFile : GameCoreSettingFile
    {
        public EntityGeneralSetting entityGeneralSetting;
        public EntitySelectionGeneralSetting entitySelectionGeneralSetting;
        public DamageGeneralSetting damageGeneralSetting;
        public SpellGeneralSetting spellGeneralSetting;
    }
}