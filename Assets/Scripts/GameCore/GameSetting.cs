using PVZRTS.Damage;
using PVZRTS.Entities;
using PVZRTS.UI;
using TH.Spells;
using VMFramework.GameLogicArchitecture;
using VMFramework.Procedure;

namespace PVZRTS.GameCore
{
    [ManagerCreationProvider(ManagerType.SettingCore)]
    public sealed partial class GameSetting : GlobalSetting<GameSetting, GameSettingFile>
    {
        public static EntityGeneralSetting entityGeneralSetting => globalSettingFile.entityGeneralSetting;
        
        public static EntitySelectionGeneralSetting entitySelectionGeneralSetting => globalSettingFile.entitySelectionGeneralSetting;
        
        public static DamageGeneralSetting damageGeneralSetting => globalSettingFile.damageGeneralSetting;
        
        public static SpellGeneralSetting spellGeneralSetting => globalSettingFile.spellGeneralSetting;
    }
}
