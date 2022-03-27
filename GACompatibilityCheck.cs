using ColossalFramework.PlatformServices;

namespace GameAnarchy {
    public static class CompatibilityCheck { 
        public readonly struct ModInfo {
            public readonly ulong fileID;
            public readonly string name;
            public readonly string specialMsg;
            public readonly bool inclusive;
            public ModInfo(ulong modID, string modName, bool isInclusive) {
                fileID = modID;
                name = modName;
                specialMsg = null;
                inclusive = isInclusive;
            }
            public ModInfo(ulong modID, string modName, bool isInclusive, string extraMsg) {
                fileID = modID;
                name = modName;
                specialMsg = extraMsg;
                inclusive = isInclusive;
            }
        }

        private static readonly ModInfo[] IncompatibleMods = new ModInfo[] {
            new ModInfo(1567569285, @"Achieve It!", true),
            new ModInfo(2037888659, @"Instant Return To Desktop", true),
            new ModInfo(466834228, @"Not So Unqiue Buildings", true),
            new ModInfo(1263262833, @"Pollution Solution", true),
            new ModInfo(973512634, @"Sort Mod Settings", true),
            new ModInfo(1665106193, @"Skip Intro", true),
        };

        internal static bool CheckIncompatibleMods() {
            string errorMsg = "";
            foreach (var mod in PlatformService.workshop.GetSubscribedItems()) {
                for (int i = 0; i < IncompatibleMods.Length; i++) {
                    if (mod.AsUInt64 == IncompatibleMods[i].fileID) {
                        errorMsg += '[' + IncompatibleMods[i].name + ']' + @" detected. " +
                            (IncompatibleMods[i].inclusive ? "Game Anarchy already includes the same functionality. " : "This mod is incompatible with Game Anarchy. ") +
                            (IncompatibleMods[i].specialMsg is null ? "\n" : IncompatibleMods[i].specialMsg + "\n\n");
                        GAMod.GALog(@"Incompatible mod: [" + IncompatibleMods[i].name + @"] detected");
                    }
                }
            }
            if (errorMsg.Length > 0) {
                GADialog.MessageBox("Game Anarchy detected incompatible mods", errorMsg);
                GAMod.GALog("Game Anarchy detected incompatible mods, please remove the following mentioned mods\n" + errorMsg);
                return false;
            }
            return true;
        }
    }
}
