using BepInEx.Bootstrap;
using HarmonyLib;

namespace FenceSnap.Patches {
    [HarmonyPatch]
    public class ObjectDBPatch {
        [HarmonyPatch(typeof(ObjectDB), nameof(ObjectDB.Awake)), HarmonyPostfix]
        public static void AfterObjectDBAwake() {
            if (!ZNetScene.instance) {
                return;
            }

            Plugin.AddVanillaSnappoints();

            if (Plugin.patchOdinArchitect.Value && Chainloader.PluginInfos.ContainsKey("com.raelaziel.OdinArchitect")) {
                Plugin.AddOdinArchitectSnappoints();
            }
        }
    }
}
