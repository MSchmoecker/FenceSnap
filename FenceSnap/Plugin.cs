using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using FenceSnap.Patches;
using HarmonyLib;

namespace FenceSnap {
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    public class Plugin : BaseUnityPlugin {
        public const string ModName = "FenceSnap";
        public const string ModGuid = "com.maxsch.valheim.FenceSnap";
        public const string ModVersion = "0.1.1";

        private Harmony harmony;

        public static ConfigEntry<bool> patchJotunnMods;
        public static ConfigEntry<bool> patchOdinArchitect;

        private void Awake() {
            Log.Init(Logger);

            patchJotunnMods = Config.Bind("Compatibility", "Jotunn", true, "Enable pathing for Jotunn mods. The patch alone does nothing, only disable it when an error occurs. Needs a restart");
            patchOdinArchitect = Config.Bind("Compatibility", "Odin Architect", true, "Enables snapping for OdinArchtiect fences. Doesn't need to be disabled when OdinArchtiect is not present. Needs a restart");

            harmony = new Harmony(ModGuid);
            harmony.PatchAll(typeof(ZNetPatch));

            if (patchJotunnMods.Value && Chainloader.PluginInfos.ContainsKey("com.jotunn.jotunn")) {
                harmony.PatchAll(typeof(JotunnPatch));
            }
        }
    }
}
