using PVZRTS.Entities;
using VMFramework.GameLogicArchitecture;

namespace PVZRTS.GameCore
{
    public class GameSetting : GameCoreSetting
    {
        public static GameSettingFile gameSettingFile => (GameSettingFile)gameCoreSettingsFile;

        public static EntityGeneralSetting entityGeneralSetting => gameSettingFile.entityGeneralSetting;
    }
}
