using HarmonyLib;
using UnityEngine;

namespace FenceSnap.Patches {
    [HarmonyPatch]
    public class ZNetPatch {
        [HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.Awake)), HarmonyPostfix]
        public static void ZNetAwake(ZNetScene __instance) {
            GameObject woodFence = __instance.m_namedPrefabs["wood_fence".GetStableHashCode()];
            CreateSnappoint(new Vector3(1f, 0f, 0), woodFence.transform);
            CreateSnappoint(new Vector3(-1f, 0f, 0), woodFence.transform);
            CreateSnappoint(new Vector3(1f, .5f, 0), woodFence.transform);
            CreateSnappoint(new Vector3(-1f, .5f, 0), woodFence.transform);

            GameObject sharpstakes = __instance.m_namedPrefabs["piece_sharpstakes".GetStableHashCode()];
            CreateSnappoint(new Vector3(1.12f, 0f, 0), sharpstakes.transform);
            CreateSnappoint(new Vector3(-1.12f, 0f, 0), sharpstakes.transform);
        }

        private static void CreateSnappoint(Vector3 pos, Transform parent) {
            GameObject snappoint = new GameObject("_snappoint");
            snappoint.transform.parent = parent;
            snappoint.transform.localPosition = pos;
            snappoint.tag = "snappoint";
        }
    }
}
