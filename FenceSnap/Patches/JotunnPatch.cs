using BepInEx.Bootstrap;
using HarmonyLib;
using UnityEngine;

namespace FenceSnap.Patches {
    [HarmonyPatch]
    public class JotunnPatch {
        [HarmonyPatch("Jotunn.Managers.PieceManager, Jotunn", "RegisterCustomData"), HarmonyPostfix]
        private static void AfterJotunnRegisterCustomData() {
            if (ZNetScene.instance == null) {
                return;
            }

            if (Chainloader.PluginInfos.ContainsKey("com.raelaziel.OdinArchitect")) {
                AddOdinArchitect();
            }
        }

        public static void AddOdinArchitect() {
            SnappointHelper.FixPiece("wooden_fence_1");

            SnappointHelper.FixPiece("wooden_fence_1_gate");
            SnappointHelper.AddSnappoints("wooden_fence_1_gate", new[] {
                new Vector3(-2.4f, 0f, 0f),
                new Vector3(-2.4f, 1.17f, 0f),
                new Vector3(0, 1.17f, 0f),
            });

            SnappointHelper.FixPiece("wooden_fence_2");
            SnappointHelper.AddSnappoints("wooden_fence_2", new[] {
                new Vector3(1.45f, 0f, 0),
                new Vector3(-1.55f, 0f, 0),
                new Vector3(1.45f, .75f, 0),
                new Vector3(-1.55f, .75f, 0),
            });

            SnappointHelper.FixPiece("wooden_fence_2_gate");
            SnappointHelper.AddSnappoints("wooden_fence_2_gate", new[] {
                new Vector3(-3f, 0f, 0),
                new Vector3(0, 0f, 0),
                new Vector3(-3f, .75f, 0),
                new Vector3(0, .75f, 0),
            });

            SnappointHelper.AddSnappoints("refined_sharpstakes", new[] {
                new Vector3(1.3f, 0f, 0.6f),
                new Vector3(-1.3f, 0f, 0.6f),
            });
        }
    }
}
