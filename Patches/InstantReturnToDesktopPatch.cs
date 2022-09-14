using System;
using System.Diagnostics;
using HarmonyLib;

namespace GameAnarchy.Patches {
    [HarmonyPatch(typeof(LoadingManager), "QuitApplication")]
    public class FastReturnPatch {
        static bool Prefix() {
            return FastReturn.Terminate();
        }
    }
    public class FastReturn {
        public static bool Terminate() {
            try {
                LoadingManager.instance.autoSaveTimer.Stop();
                Process.GetCurrentProcess().Kill();
                return false;
            } catch (Exception e) {
                UnityEngine.Debug.Log(e);
            }
            return false;
        }
    }

    



}
