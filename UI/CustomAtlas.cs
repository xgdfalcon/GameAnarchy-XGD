using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColossalFramework;
using ColossalFramework.UI;

namespace GameAnarchy.UI {
    public static class CustomAtlas {

        // ------Tab Button------
        public static string TabButtonNormal => nameof(TabButtonNormal);
        public static string TabButtonHovered => nameof(TabButtonHovered);
        public static string TabButtonPressed => nameof(TabButtonPressed);

        // ------Setting Toggle Button------
        public static string SettingToggleButtonDisabled => nameof(SettingToggleButtonDisabled);
        public static string SettingToggleButtonEnabled => nameof(SettingToggleButtonEnabled);

        // ------Setting Button------
        public static string SettingButtonNormal => nameof(SettingButtonNormal);
        public static string SettingButtonHovered => nameof(SettingButtonHovered);
        public static string SettingButtonPressed => nameof(SettingButtonPressed);

        // ------Flag------
        public static string NormalFlag => nameof(NormalFlag);
        public static string WarningFlag => nameof(WarningFlag);

        public static string[] SettingButtons = new string[] {
            TabButtonNormal,
            TabButtonHovered,
            TabButtonPressed,
            SettingToggleButtonDisabled,
            SettingToggleButtonEnabled,
            SettingButtonNormal,
            SettingButtonHovered,
            SettingButtonPressed,
            NormalFlag,
            WarningFlag,
        };

        public static UITextureAtlas CommonAtlas => GAUtils.CreateTextureAtlas(@"CommonAtlas", @"GameAnarchy.Resources.", SettingButtons, 1024);


    }
}
