using ColossalFramework.PlatformServices;
using System.Collections.Generic;

namespace GameAnarchy {
    public static class GACompatibilityCheck {
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
            new ModInfo(458519223, @"Unlock All + Wonders & Landmarks", true),
            new ModInfo(769744928, @"Pollution, Death, Garbage and Crime Remover Mod", true),
            new ModInfo(1237383751, @"Extended Game Options", true),
            new ModInfo(1498036881, @"UltimateMod 2.10.2 [STABLE]", true),
            new ModInfo(2506369356, @"UltimateMod v2.12.11 [BETA]", true),  
        };

        
        internal static List<string> GetListMods = new List<string>();
        internal static bool CheckIncompatibleMods() {
            string errorMsg = "";
            string errorMsgList;
            foreach (var mod in PlatformService.workshop.GetSubscribedItems()) {
                for (int i = 0; i < IncompatibleMods.Length; i++) {
                    if (mod.AsUInt64 == IncompatibleMods[i].fileID) {
                        errorMsg += '[' + IncompatibleMods[i].name + ']' + @"  -  " +
                            (IncompatibleMods[i].inclusive ? "Game Anarchy already includes the same functionality.\n" : "This mod is incompatible with Game Anarchy.\n") +
                            (IncompatibleMods[i].specialMsg is null ? "" : IncompatibleMods[i].specialMsg + "");
                        errorMsgList = '[' + IncompatibleMods[i].name + ']' + @"  -  " +
                            (IncompatibleMods[i].inclusive ? GALocale.GetLocale(@"SameFunctionality") : GALocale.GetLocale(@"Incompatible")) +
                            (IncompatibleMods[i].specialMsg is null ? "" : IncompatibleMods[i].specialMsg + "");
                        //GAMod.GALog(@"Incompatible mod: [" + IncompatibleMods[i].name + @"] detected");
                        GetListMods.Add(errorMsgList);
                    }
                }
            }
            if (errorMsg.Length > 0) {
                GAMod.GALog("Game Anarchy detected incompatible mods, please remove the following mentioned mods.\n" + errorMsg);
                return true;
            }
            return false;
        }
    }
}
