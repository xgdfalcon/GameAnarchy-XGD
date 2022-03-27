using ColossalFramework;
using ColossalFramework.Globalization;
using ColossalFramework.Plugins;
using ColossalFramework.UI;
using HarmonyLib;
using System;
using UnityEngine;

namespace GameAnarchy.Patches {
    class AchievementManager : MonoBehaviour {
        public void Update() {
            if (GAMod.EnabledAchievements) {
                ToggleAchievements();
                //GAMod.EnableAchievement = false;
            }
        }
        private void ToggleAchievements() {
            try {
                if (GAMod.EnabledAchievements) {
                    Singleton<SimulationManager>.instance.m_metaData.m_disableAchievements = SimulationMetaData.MetaBool.False;
                } else {
                    Singleton<SimulationManager>.instance.m_metaData.m_disableAchievements = SimulationMetaData.MetaBool.True;
                }
                UIButton button = GameObject.Find("Achievements").GetComponent<UIButton>();
                if (button != null) {
                    button.isEnabled = GAMod.EnabledAchievements;
                }
            }
            catch (Exception e) {
                Debug.Log("[Achieve It!] ModManager:ToggleAchievements -> Exception: " + e.Message);
            }
        }

    }

    [HarmonyPatch(typeof(LoadPanel), "OnListingSelectionChanged")]
    public static class AchievementPatch {
        static void Postfix(UIComponent comp, int sel) {
            try {
                if (GAMod.EnabledAchievements) {
                    UISprite m_AchNope = comp.parent.Find<UISprite>("AchNope");
                    UIComponent m_Ach = comp.parent.Find("Ach");
                    UIComponent m_AchAvLabel = comp.parent.Find("AchAvLabel");
                    m_AchNope.isVisible = false;
                    string tooltip = string.Empty;
                    tooltip = Locale.Get("LOADPANEL_ACHSTATUS_ENABLED");
                    tooltip += "<color #50869a>";
                    if (Singleton<PluginManager>.instance.enabledModCountNoOverride > 0) {
                        tooltip += Environment.NewLine;
                        tooltip += LocaleFormatter.FormatGeneric("LOADPANEL_ACHSTATUS_MODSACTIVE", Singleton<PluginManager>.instance.enabledModCount);
                    }
                    tooltip += "</color>";
                    m_Ach.tooltip = tooltip;
                    m_AchAvLabel.tooltip = tooltip;
                }
            }
            catch (Exception e) {
                Debug.Log("[Achieve It!] LoadPanelPatch:Postfix -> Exception: " + e.Message);
            }
        }
    }
}
