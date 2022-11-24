using System.Collections.Generic;
using UnityEngine;

namespace FenceSnap {
    public static class SnappointHelper {
        public static void AddSnappoints(string name, bool fixPiece, IEnumerable<Vector3> points) {
            GameObject target = ZNetScene.instance.GetPrefab(name);

            if (!target) {
                Log.LogWarning($"Prefab {name} not found. Cannot add snappoints");
                return;
            }

            if (fixPiece) {
                FixPiece(name);
            }

            foreach (Vector3 point in points) {
                CreateSnappoint(point, target.transform);
            }
        }

        private static void CreateSnappoint(Vector3 pos, Transform parent) {
            GameObject snappoint = new GameObject("_snappoint");
            snappoint.transform.parent = parent;
            snappoint.transform.localPosition = pos;
            snappoint.tag = "snappoint";
            snappoint.SetActive(false);
        }

        public static void FixPiece(string name) {
            GameObject target = ZNetScene.instance.GetPrefab(name);

            if (!target) {
                Log.LogWarning($"Prefab {name} not found. Cannot fix piece");
                return;
            }

            foreach (Collider collider in target.GetComponentsInChildren<Collider>()) {
                collider.gameObject.layer = LayerMask.NameToLayer("piece");
            }
        }
    }
}
