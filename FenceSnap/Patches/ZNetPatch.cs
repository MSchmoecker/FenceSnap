using HarmonyLib;
using UnityEngine;

namespace FenceSnap.Patches {
    [HarmonyPatch]
    public class ZNetPatch {
        [HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.Awake)), HarmonyPostfix]
        public static void AfterZNetSceneAwake() {
            SnappointHelper.AddSnappoints("wood_fence", new[] {
                new Vector3(1f, 0f, 0),
                new Vector3(-1f, 0f, 0),
                new Vector3(1f, .5f, 0),
                new Vector3(-1f, .5f, 0),
            });

            SnappointHelper.AddSnappoints("piece_sharpstakes", new[] {
                new Vector3(1.12f, 0f, 0),
                new Vector3(-1.12f, 0f, 0),
            });
        }
    }
}
