using System.Collections.Generic;
using UnityEngine;

namespace FenceSnap {
    public static class SnappointHelper {
        public static void AddSnappoints(string name, bool fixPiece, bool fixZClipping, IEnumerable<Vector3> points) {
            GameObject target = ZNetScene.instance.GetPrefab(name);

            if (!target) {
                Log.LogWarning($"Prefab {name} not found. Cannot add snappoints");
                return;
            }

            if (fixPiece) {
                FixPiece(name);
            }

            float z = 0f;

            foreach (Vector3 point in points) {
                Vector3 pos = point;

                if (fixZClipping) {
                    pos.z = z;
                    z += 0.0001f;
                }

                CreateSnappoint(pos, target.transform);
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
