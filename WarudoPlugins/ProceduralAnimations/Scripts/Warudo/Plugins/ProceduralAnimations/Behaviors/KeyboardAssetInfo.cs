using UnityEngine;

namespace Warudo.Plugins.ProceduralAnimations.Behaviors {
    public class KeyboardAssetInfo : MonoBehaviour {

        public GameObject axisReferenceObject;
        public Vector3 upAxis;
        public Vector3 forwardAxis;

        public bool debug;
        
        public Vector3 Up => axisReferenceObject.transform.TransformDirection(upAxis);
        public Vector3 Forward => axisReferenceObject.transform.TransformDirection(forwardAxis);
        public Vector3 Right => Vector3.Cross(Up, Forward);

        private void Update() {
            if (debug) {
                var position = transform.position;
                Debug.DrawLine(position, position + Up, Color.green);
                Debug.DrawLine(position, position + Forward, Color.blue);
                Debug.DrawLine(position, position + Right, Color.red);
            }
        }

    }
}
