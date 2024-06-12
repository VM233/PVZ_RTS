using PVZRTS.Damage;
using PVZRTS.Entities;
using PVZRTS.UI;
using VMFramework.GameLogicArchitecture;

namespace PVZRTS.GameCore
{
    public class GameSetting : GameCoreSetting
    {
        public static GameSettingFile gameSettingFile => (GameSettingFile)gameCoreSettingsFile;

        public static EntityGeneralSetting entityGeneralSetting => gameSettingFile.entityGeneralSetting;
        
        public static EntitySelectionGeneralSetting entitySelectionGeneralSetting => gameSettingFile.entitySelectionGeneralSetting;
        
        public static DamageGeneralSetting damageGeneralSetting => gameSettingFile.damageGeneralSetting;
    }
}
