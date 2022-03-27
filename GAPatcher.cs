using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using ColossalFramework;
using ColossalFramework.Plugins;
using ICities;
using System.Linq;

namespace GameAnarchy {
    internal static class GAPatcher {
        private const string HARMONYID = @"com.mbyron26.GameAanrchy";

        internal static void EnablePatches() {
            Harmony harmony = new Harmony(HARMONYID);
            harmony.PatchAll();
			var addUserModsOriginal = typeof(OptionsMainPanel).GetMethod("AddUserMods", BindingFlags.NonPublic | BindingFlags.Instance);
			var addUserModsTranspiler = typeof(GAPatcher).GetMethod(nameof(AddUserModsTranspiler), BindingFlags.Public | BindingFlags.Static);
			harmony.Patch(addUserModsOriginal, null, null, new HarmonyMethod(addUserModsTranspiler));

			if (GAMod.EnabledSkipIntro) {
				var loadIntroCoroutineOriginal = typeof(LoadingManager).GetNestedTypes(BindingFlags.NonPublic)
				.Single(x => x.FullName == "LoadingManager+<LoadIntroCoroutine>c__Iterator0").GetMethod("MoveNext", BindingFlags.Public | BindingFlags.Instance);
				var loadIntroCoroutineTranspiler = typeof(GAPatcher).GetMethod(nameof(LoadIntroCoroutineTranspiler), BindingFlags.NonPublic | BindingFlags.Static);
				harmony.Patch(loadIntroCoroutineOriginal, null, null, new HarmonyMethod(loadIntroCoroutineTranspiler));
			}
		}

        internal static void DisablePatches() {
            Harmony harmony = new Harmony(HARMONYID);
            harmony.UnpatchAll(HARMONYID);
        }


		public static IEnumerable<CodeInstruction> AddUserModsTranspiler(IEnumerable<CodeInstruction> codeInstructions) {
			var hookOpCode = OpCodes.Callvirt;
			var hookOperand = typeof(PluginManager).GetMethod("GetPluginsInfo", BindingFlags.Public | BindingFlags.Instance);
			var replacementMethod = typeof(GAPatcher).GetMethod(nameof(GetPluginsInfoInOrder), BindingFlags.Public | BindingFlags.Static);
			var instructions = codeInstructions.ToList();
			for (int i = 0; i < instructions.Count; i++) {
				var instruction = instructions[i];
				if (instruction.opcode == hookOpCode && instruction.operand == hookOperand) {
					instruction.opcode = OpCodes.Call;
					instruction.operand = replacementMethod;
					instructions.RemoveAt(i - 1);
					break;
				}
			} return instructions;
		}

		public static IEnumerable<PluginManager.PluginInfo> GetPluginsInfoInOrder() => Singleton<PluginManager>.instance.GetPluginsInfo().Where(p => p?.userModInstance as IUserMod != null).OrderBy(p => ((IUserMod)p.userModInstance).Name);

		private static IEnumerable<CodeInstruction> LoadIntroCoroutineTranspiler(IEnumerable<CodeInstruction> codeInstructions) {
			var menuSceneField = typeof(LoadingManager).GetNestedTypes(BindingFlags.NonPublic).Single(x => x.FullName == "LoadingManager+<LoadIntroCoroutine>c__Iterator0").GetField("<menuScene>__0", BindingFlags.NonPublic | BindingFlags.Instance);
			var codes = codeInstructions.ToList();
			for (int i = 0; i < codes.Count; i++) {
				var code = codes[i];
				if (code.opcode == OpCodes.Ldstr && (code.operand as string == "IntroScreen" || code.operand as string == "IntroScreen2")) {
					code.operand = string.Empty;
				}
				if (code.opcode == OpCodes.Ldc_R4 && (code.operand as float? == 4f //wait time of IntroScreen and FadeImage
						|| code.operand as float? == 1f //wait time of IntroScreen2
						|| code.operand as float? == 20f //wait time for IsDLCStateReady and LegalDocumentsReady
					)) {
					code.operand = 0f;
				}
				if (code.opcode == OpCodes.Ldarg_0
					&& codes[i + 1].opcode == OpCodes.Ldarg_0
					&& codes[i + 2].opcode == OpCodes.Ldfld && codes[i + 2].operand == menuSceneField
					&& codes[i + 3].opcode == OpCodes.Ldc_I4_1) {
					codes[i + 3].opcode = OpCodes.Ldc_I4_0;
				}
			}
			return codes;
		}
	}
}
