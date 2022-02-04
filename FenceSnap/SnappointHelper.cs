using UnityEngine;

namespace FenceSnap {
    public class SnappointHelper {
        public static void AddSnappoints(string name, Vector3[] points) {
            GameObject target = ZNetScene.instance.GetPrefab(name);

            if (target == null) {
                Log.LogInfo($"{name} not found. Cannot add snappoints");
                return;
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

            if (target == null) {
                Log.LogInfo($"{name} not found. Cannot add fix piece");
                return;
            }

            foreach (Collider collider in target.GetComponentsInChildren<Collider>()) {
                collider.gameObject.layer = LayerMask.NameToLayer("piece");
            }
        }
    }
}
