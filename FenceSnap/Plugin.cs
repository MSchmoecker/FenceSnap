using BepInEx;
using BepInEx.Bootstrap;
using FenceSnap.Patches;
using HarmonyLib;

namespace FenceSnap {
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    public class Plugin : BaseUnityPlugin {
        public const string ModName = "FenceSnap";
        public const string ModGuid = "com.maxsch.valheim.FenceSnap";
        public const string ModVersion = "0.1.0";

        private Harmony harmony;

        private void Awake() {
            Log.Init(Logger);
            harmony = new Harmony(ModGuid);
            harmony.PatchAll(typeof(ZNetPatch));

            if (Chainloader.PluginInfos.ContainsKey("com.jotunn.jotunn")) {
                harmony.PatchAll(typeof(JotunnPatch));
            }
        }
    }
}
