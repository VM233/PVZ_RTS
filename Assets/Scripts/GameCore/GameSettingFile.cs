using PVZRTS.Damage;
using PVZRTS.Entities;
using PVZRTS.UI;
using TH.Spells;
using VMFramework.GameLogicArchitecture;
using VMFramework.GameLogicArchitecture.Editor;

namespace PVZRTS.GameCore
{
    [GlobalSettingFileConfig(FileName = nameof(GameSettingFile))]
    [GlobalSettingFileEditorConfig(FolderPath = ConfigurationPath.DEFAULT_GLOBAL_SETTINGS_PATH)]
    public sealed partial class GameSettingFile : GlobalSettingFile
    {
        public EntityGeneralSetting entityGeneralSetting;
        public EntitySelectionGeneralSetting entitySelectionGeneralSetting;
        public DamageGeneralSetting damageGeneralSetting;
        public SpellGeneralSetting spellGeneralSetting;
    }
}