using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;

namespace GameAnarchy.Patches {

    [HarmonyPatch(typeof(CommercialBuildingAI), "GetFireParameters")]
    internal static class CommercialBuildingAIPatch {
        public static void Postfix(ref int fireTolerance) {
            if (GAMod.RemoveFire) fireTolerance = 1000;
            else if (!GAMod.RemoveFire) fireTolerance = 10;
        }
    }

    [HarmonyPatch(typeof(IndustrialExtractorAI), "GetFireParameters")]
    internal static class IndustrialExtractorAIPatch {
        public static void Postfix(ref int fireTolerance) {
            if (GAMod.RemoveFire) fireTolerance = 1000;
            else if (!GAMod.RemoveFire) fireTolerance = 10;
        }
    }

    [HarmonyPatch(typeof(OfficeBuildingAI), "GetFireParameters")]
    internal static class OfficeBuildingAIPatch {
        public static void Postfix(ref int fireTolerance) {
            if (GAMod.RemoveFire) fireTolerance = 1000;
            else if (!GAMod.RemoveFire) fireTolerance = 10;
        }
    }

    [HarmonyPatch(typeof(PlayerBuildingAI), "GetFireParameters")]
    internal static class PlayerBuildingAIFirePatch {
        public static void Postfix(ref int fireTolerance) {
            if (GAMod.RemoveFire) fireTolerance = 1000;
            else if (!GAMod.RemoveFire) fireTolerance = 20;
        }
    }

    [HarmonyPatch(typeof(ResidentialBuildingAI), "GetFireParameters")]
    internal static class ResidentialBuildingAIPatch {
        public static void Postfix(ref int fireTolerance) {
            if (GAMod.RemoveFire) fireTolerance = 1000;
            else if (!GAMod.RemoveFire) fireTolerance = 8;
        }
    }

    [HarmonyPatch(typeof(MuseumAI), "GetFireParameters")]
    internal static class MuseumAIPatch {
        public static void Postfix(ref int fireTolerance) {
            if (GAMod.RemoveFire) fireTolerance = 1000;
            else if (!GAMod.RemoveFire) fireTolerance = 20;
        }
    }

    [HarmonyPatch(typeof(IndustrialBuildingAI), "GetFireParameters")]
    internal static class IndustrialBuildingAIPatch {
        public static void Postfix(ref int fireTolerance) {
            if (GAMod.RemoveFire) fireTolerance = 1000;
            else if (!GAMod.RemoveFire) fireTolerance = 10;
        }
    }

    [HarmonyPatch(typeof(DummyBuildingAI), "GetFireParameters")]
    internal static class DummyBuildingAIPatch {
        public static void Postfix(ref int fireTolerance) {
            if (GAMod.RemoveFire) fireTolerance = 1000;
            else if (!GAMod.RemoveFire) fireTolerance = 20;
        }
    }
    [HarmonyPatch(typeof(CampusBuildingAI), "GetFireParameters")]
    internal static class CampusBuildingAIPatch {
        public static void Postfix(ref int fireTolerance) {
            if (GAMod.RemoveFire) fireTolerance = 1000;
            else if (!GAMod.RemoveFire) fireTolerance = 20;
        }
    }

    [HarmonyPatch(typeof(AirportGateAI), "GetFireParameters")]
    internal static class AirportGateAIPatch {
        public static void Postfix(ref int fireTolerance) {
            if (GAMod.RemoveFire) fireTolerance = 1000;
            else if (!GAMod.RemoveFire) fireTolerance = 20;
        }
    }

    [HarmonyPatch(typeof(AirportCargoGateAI), "GetFireParameters")]
    internal static class AirportCargoGateAIPatch {
        public static void Postfix(ref int fireTolerance) {
            if (GAMod.RemoveFire) fireTolerance = 1000;
            else if (!GAMod.RemoveFire) fireTolerance = 20;
        }
    }
    [HarmonyPatch(typeof(AirportBuildingAI), "GetFireParameters")]
    internal static class AirportBuildingAIPatch {
        public static void Postfix(ref int fireTolerance) {
            if (GAMod.RemoveFire) fireTolerance = 1000;
            else if (!GAMod.RemoveFire) fireTolerance = 20;
        }
    }
    //[HarmonyPatch(typeof(BuildingInfo), "InitializePrefab")]
    //internal static class GetBuildingInfoPatch {
    //    public static void Postfix(BuildingInfo __instance) {
    //        if (!__instance.m_buildingAI.GetType().IsSubclassOf(typeof(PlayerBuildingAI)))
    //            return;
    //        if (GAMod.RemoveFire)
    //            __instance.m_buildingAI.GetType().GetField("m_fireTolerance").SetValue(__instance.m_buildingAI, 1000);
    //        else if (!GAMod.RemoveFire)
    //            __instance.m_buildingAI.GetType().GetField("m_fireTolerance").SetValue(__instance.m_buildingAI, 20);

    //    }
    //}



}
