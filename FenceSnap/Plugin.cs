using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace FenceSnap {
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    public class Plugin : BaseUnityPlugin {
        public const string ModName = "FenceSnap";
        public const string ModGuid = "com.maxsch.valheim.FenceSnap";
        public const string ModVersion = "0.3.0";

        public static ConfigEntry<bool> patchOdinArchitect;

        private void Awake() {
            Log.Init(Logger);

            patchOdinArchitect = Config.Bind("Compatibility", "Odin Architect", true, "Enables snapping for OdinArchitect fences. Does not need to be disabled when OdinArchitect is not installed. Needs a restart");

            Harmony harmony = new Harmony(ModGuid);
            harmony.PatchAll();
        }

        public static void AddVanillaSnappoints() {
            SnappointHelper.AddSnappoints("wood_fence", false, true, new[] {
                new Vector3(+1f, -0.2f, 0),
                new Vector3(-1f, -0.2f, 0),
                new Vector3(1f, 0f, 0),
                new Vector3(-1f, 0f, 0),
                new Vector3(1f, 0.2f, 0),
                new Vector3(-1f, 0.2f, 0),
                new Vector3(1f, 0.4f, 0),
                new Vector3(-1f, 0.4f, 0),
                new Vector3(1f, 0.6f, 0),
                new Vector3(-1f, 0.6f, 0),
                new Vector3(1f, 0.8f, 0),
                new Vector3(-1f, 0.8f, 0),
                new Vector3(1f, 1f, 0),
                new Vector3(-1f, 1f, 0),
            });

            SnappointHelper.AddSnappoints("piece_sharpstakes", false, false, new[] {
                new Vector3(1.12f, -0.2f, 0),
                new Vector3(-1.12f, -0.2f, 0),
                new Vector3(1.12f, 0f, 0),
                new Vector3(-1.12f, 0f, 0),
                new Vector3(1.12f, 0.2f, 0),
                new Vector3(-1.12f, 0.2f, 0),
            });

            SnappointHelper.AddSnappoints("piece_dvergr_sharpstakes", false, false, new[] {
                new Vector3(-0.5f, -0.5f, 2f),
                new Vector3(-0.5f, -0.5f, -2f),
                new Vector3(-0.5f, 0f, 2f),
                new Vector3(-0.5f, 0f, -2f),
                new Vector3(1f, 1f, 2f),
                new Vector3(1f, 1f, -2f),
            });
        }

        public static void AddOdinArchitectSnappoints() {
            SnappointHelper.FixPiece("wooden_fence_1");

            SnappointHelper.AddSnappoints("wooden_fence_1_gate", true,  true, new[] {
                new Vector3(-2.4f, 0f, 0f),
                new Vector3(-2.4f, 1.17f, 0f),
                new Vector3(0, 1.17f, 0f),
            });

            SnappointHelper.AddSnappoints("wooden_fence_2", true, true, new[] {
                new Vector3(1.45f, 0f, 0),
                new Vector3(-1.55f, 0f, 0),
                new Vector3(1.45f, 0.4f, 0),
                new Vector3(-1.55f,0.4f, 0),
                new Vector3(1.45f, 0.8f, 0),
                new Vector3(-1.55f, 0.8f, 0),
            });

            SnappointHelper.AddSnappoints("wooden_fence_2_gate", true, true, new[] {
                new Vector3(-3f, 0f, 0),
                new Vector3(0, 0f, 0),
                new Vector3(-3f, .4f, 0),
                new Vector3(0, .4f, 0),
                new Vector3(-3f, .8f, 0),
                new Vector3(0, .8f, 0),
            });

            SnappointHelper.AddSnappoints("refined_sharpstakes", false, false, new[] {
                new Vector3(1.3f, 0f, 0.6f),
                new Vector3(-1.3f, 0f, 0.6f),
            });
        }
    }
}
