using HarmonyLib;
using System.Runtime.CompilerServices;

namespace GameAnarchy.Patches {
    [HarmonyPatch(typeof(MonumentAI))]
    [HarmonyPatch(nameof(MonumentAI.CanBeBuiltOnlyOnce))]
    internal class MonumentAIPatch {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Prefix(ref bool __result) {
            __result = false;
            return false;
        }
    }

    [HarmonyPatch(typeof(PlayerBuildingAI))]
    [HarmonyPatch(nameof(PlayerBuildingAI.CanBeBuiltOnlyOnce))]
    internal class PlayerBuildingAIPatch {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Prefix(ref bool __result) {
            __result = false;
            return false;
        }
    }

    [HarmonyPatch(typeof(SpaceRadarAI))]
    [HarmonyPatch(nameof(SpaceRadarAI.CanBeBuiltOnlyOnce))]
    internal class SpaceRadarAIPatch {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Prefix(ref bool __result) {
            __result = false;
            return false;
        }
    }

    [HarmonyPatch(typeof(UniqueFactoryAI))]
    [HarmonyPatch(nameof(UniqueFactoryAI.CanBeBuiltOnlyOnce))]
    internal class UniqueFactoryAIPatch {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Prefix(ref bool __result) {
            __result = false;
            return false;
        }
    }

    [HarmonyPatch(typeof(WeatherRadarAI))]
    [HarmonyPatch(nameof(WeatherRadarAI.CanBeBuiltOnlyOnce))]
    internal class WeatherRadarAIPatch {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Prefix(ref bool __result) {
            __result = false;
            return false;
        }
    }


}
